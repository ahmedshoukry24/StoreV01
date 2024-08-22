using API.Helper;
using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _context;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
        {
            categoryDto.Serial = RandomSerial.GenerateSerial(10);
            Category cat = this._mapper.Map<Category>(categoryDto);
            Category res =  await this._context.Add(cat);
            if (res != null)
                return BadRequest("something went wrong!");
            else
                return Ok("Category Added!");
        }
    }
}
