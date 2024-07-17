using API.DTOs;
using AutoMapper;
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
            Category cat = this._mapper.Map<Category>(categoryDto);
            bool res =  await this._context.Add(cat);
            if (!res)
                return BadRequest("something went wrong!");
            else
                return Ok("Category Added!");
        }
    }
}
