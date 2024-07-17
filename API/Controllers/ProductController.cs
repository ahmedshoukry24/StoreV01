﻿using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _context;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Product product = this._mapper.Map<Product>(productDto);
            bool res =  await this._context.Add(product);
            if (!res)
                return BadRequest("Something went wrong!");
            else
                return Ok("Product Added!");
        }

        [HttpGet]
        [Route("Products")]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            List<Product> products = await this._context.GetAll();
            if (products == null)
                return BadRequest("No Products!");
            if (products.Count == 0)
                return NotFound("No Products Added yet!");

            List<ProductDto> productsDto =  this._mapper.Map<List<ProductDto>>(products);
            return Ok(productsDto);

        }
    }
}
