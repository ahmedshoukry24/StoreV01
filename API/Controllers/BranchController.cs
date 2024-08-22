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
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _context;
        private readonly IMapper _mapper;
        public BranchController(IBranchRepository context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateBranch(BranchDto branchDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Branch branch = this._mapper.Map<Branch>(branchDto);
            

            Branch result = await this._context.Add(branch);

            if (result != null)
                return CreatedAtAction("GetBranch",new {id = result.ID},result);
            else
                return BadRequest("Something wend wrong!");
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetBranch(Guid id)
        {
            Branch branch = await _context.GetByIdAsync(id);

            BranchDto branchDto = _mapper.Map<BranchDto>(branch);
            if (branch == null)
                return BadRequest("No Branch found!");
            return Ok(branch);
        }

        [HttpGet]
        [Route("GetByStore/{storeId}")]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetAllByStore(Guid storeId)
        {
            IEnumerable<Branch> branches = await _context.GetAllByStore(storeId);

            IEnumerable<BranchDto> branchsDto = _mapper.Map<IEnumerable<BranchDto>>(branches);
            if (branchsDto.Count() == 0)
                return Ok("No Branched Found!");
            return Ok(branchsDto);

        }


    }
}
