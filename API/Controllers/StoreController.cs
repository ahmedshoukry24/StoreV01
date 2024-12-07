using API.Helper;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Responses;
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
        //[Authorize(Roles = "Vendor")]
        public async Task<ActionResult<StoreResponse>> CreateStore(StoreDto storeDto)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToList();
                string errorMessage = string.Join(";", errors);

                return BadRequest(StoreResponse.ErrorResponse(errorMessage));
            }
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            
            //string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (userId != storeDto.VendorId)
            //    return Unauthorized(StoreResponse.ErrorResponse("Something wrong with user authorization!"));



            //StoreResponse.ErrorResponse("Something wrong with user authorization!")

            Store store = _mapper.Map<Store>(storeDto);
            

            Store result = await _context.Add(store);


            if (result != null)
                return Ok(StoreResponse.SuccessResponse("Store Created Successfully!",result.ID,result.Name));
            else
                return BadRequest(StoreResponse.ErrorResponse("Something wend wrong!"));
        }



        [HttpGet]
        [Route("Stores")]
        //[Authorize(Roles ="Vendor")]
        public async Task<ActionResult<IEnumerable<Store>>> GetAll()
        {
            List<StoreDto> stores = _mapper.Map<List<StoreDto>>(await this._context.GetAll());
            return Ok(stores);
        }

        [HttpGet]
        [Route("Stores/{id}")]
        [Authorize(Roles ="Vendor")]
        public async Task<ActionResult<IEnumerable<Store>>> GetAll(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == id.ToString())
            {
                List<StoreDto> stores = _mapper.Map<List<StoreDto>>(await this._context.GetAll(id));
                if (stores == null)
                    return BadRequest("Something went wrong!");
                if (stores.Count == 0)
                    return BadRequest("No stores added yet!");
                
                return Ok(stores);
            }
            return BadRequest("Unauthorized to see these stores!");

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

            if (existingStore.VendorId.ToString() != vendorId)
                return Forbid("Unautorized vendor!");

            UpdateEntitiesHelper.UpdateStore(existingStore, storeDto);

            //Store store = _mapper.Map<Store>(storeDto);

            await this._context.Update(existingStore);

            return Ok("Store Updated!");

        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteStore(Guid id)
        {
            Store store = await this._context.GetByIdAsync(id);
            if (store != null)
                return BadRequest("Store doesn't exist!");

            string? vendorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (store?.VendorId.ToString() != vendorId)
                return Forbid("Unautorized vendor!");

            await this._context.Delete(store);

            return Ok("Deleted Sucessfully!");
        }

    }
}
