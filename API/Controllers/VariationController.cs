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
    public class VariationController : ControllerBase
    {
        private readonly IVariationRepository _context;
        private readonly IMapper _mapper;

        public VariationController(IVariationRepository context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Variation>> CreateVariation(VariationDto variationDto)
        {
           
             Variation createdVariation = await _context.Add(_mapper.Map<Variation>(variationDto));

            return CreatedAtAction("GetVariation",new { createdVariation.ID },createdVariation);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<VariationDto>> GetVariation(Guid id)
        {
            Variation variation = await _context.GetByIdAsync(id);

            if (variation == null) return BadRequest("No variation found!");



            return Ok(_mapper.Map<VariationDto>(variation));
        }



        [HttpGet]
        [Route("GetAll/{productId}")]
        public async Task<ActionResult<IEnumerable<VariationDto>>> GetAll(Guid productId)
        {
            IEnumerable<Variation> variations = await _context.GetAll(productId);
            return Ok(_mapper.Map<IEnumerable<VariationDto>>(variations));

        }
    }
}
