using API.DTOs;
using API.Helper;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateStore(StoreDto storeDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            Store store = new Store
            {
                Name = storeDto.Name,
                Description = storeDto.Description,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = false,
                Address = storeDto.Address,
                PhoneNumber=storeDto.PhoneNumber,
                EmailAddress = storeDto.EmailAddress
            };

            bool result = await _context.Add(store);
            

            if (result)
                return Ok("Store Created Successfully!");
            else
                return BadRequest("something wend wrong!");
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<ActionResult<Store>> UpdateStore(Guid id, [FromBody]StoreDto storeDto)
        {
            Store existingStore =  await this._context.GetByIdAsync(id);

            if (existingStore == null)
                return BadRequest("Store doesn't exist!");

            UpdateEntitiesHelper.UpdateStore(existingStore, storeDto);

            //Store store = _mapper.Map<Store>(storeDto);

            await this._context.Update(existingStore);

            return Ok("Store Updated!");

        }
    }
}
