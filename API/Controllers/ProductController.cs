﻿using API.Helper;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            Product res =  await this._context.Add(product);
            if (res == null)
                return BadRequest("Something went wrong!");
            else
                return Ok("Product Added!");
        }

        [HttpGet]
        [Route("Products")]
        //[Authorize(Policy = "specificVendors")]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            List<Product> products = await this._context.GetAll();
            if (products == null)
                return BadRequest("No Products!");
            //if (products.Count == 0)
            //    return NotFound("No Products Added yet!");

            List<ProductDto> productsDto =  this._mapper.Map<List<ProductDto>>(products);
            return Ok(productsDto);

        }

        [HttpGet]
        [Route("SearchProductChange")]
        public async Task<IActionResult> GetSearchProductChange(string searchText)
        {
            IList<ProductSearchProps> result = await _context.GetSearchProductChange(searchText);
            
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByCategoryId/{categoryId}")]
        public async Task<ActionResult<IList<ProductSearchProps>>> GetByCategoryId(Guid categoryId)
        {
            IList<ProductSearchProps> products = await _context.GetProductByCategoryId(categoryId);
            return Ok(products);
        }

        

       

    }
}
