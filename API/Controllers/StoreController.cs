using API.Helper;
using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _context;
        private readonly IMapper _mapper;
        public StoreController(IStoreRepository context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        //[Authorize(Roles ="Vendor")]
        public async Task<IActionResult> CreateStore(StoreDto storeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != storeDto.VendorId)
                return Forbid("Something wrong with user authorization!");

            Store store = _mapper.Map<Store>(storeDto);
            //    new Store
            //{
            //    Name = storeDto.Name,
            //    Description = storeDto.Description,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = false,
            //    //Address = storeDto.Address,
            //    PhoneNumber = storeDto.PhoneNumber,
            //    EmailAddress = storeDto.EmailAddress,
            //    VendorId = storeDto.VendorId
            //};

            Store result = await _context.Add(store);


            if (result != null)
                return Ok("Store Created Successfully!");
            else
                return BadRequest("Something wend wrong!");
        }

        [HttpGet]
        [Route("Stores")]
        public async Task<ActionResult<IEnumerable<Store>>> GetAll()
        {
            List<StoreDto> stores = _mapper.Map<List<StoreDto>>(await this._context.GetAll());
            return Ok(stores);
        }

        [HttpGet]
        [Route("withBranches")]
        public async Task<ActionResult<IEnumerable<StoreDto>>> GetAllWithBranches()
        {
            var stores = await this._context.GetAllWithBranches();
            if (stores == null)
                return BadRequest("No stores exist!");
            
               List<StoreDto> storeDto =  this._mapper.Map<List<StoreDto>>(stores);
            
            return Ok(storeDto);
        }



        [HttpPost]
        [Route("Update/{id}")]
        public async Task<ActionResult<Store>> UpdateStore(Guid id, [FromBody] StoreDto storeDto)
        {
            
            Store existingStore = await this._context.GetByIdAsync(id);

           
            if (existingStore == null)
                return BadRequest("Store doesn't exist!");

            string? vendorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (existingStore.VendorId != vendorId)
                return Forbid("Unautorized vendor!");

            UpdateEntitiesHelper.UpdateStore(existingStore, storeDto);

            //Store store = _mapper.Map<Store>(storeDto);

            await this._context.Update(existingStore);

            return Ok("Store Updated!");

        }

        [HttpDelete]
        [Route("Dalete/{id}")]
        public async Task<IActionResult> DeleteStore(Guid id)
        {
            Store store = await this._context.GetByIdAsync(id);
            if (store != null)
                return BadRequest("Store doesn't exist!");

            string? vendorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (store?.VendorId != vendorId)
                return Forbid("Unautorized vendor!");

            await this._context.Delete(store);

            return Ok("Deleted Sucessfully!");
        }

    }
}
