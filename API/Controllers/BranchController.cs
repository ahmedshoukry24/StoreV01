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
            branch.CreatedDate = DateTime.Now;
            branch.ModifiedDate = DateTime.Now;
            branch.IsActive = false;

            bool result = await this._context.Add(branch);

            if (result)
                return Ok("Branch created sucsessfully!");
            else
                return BadRequest("Something wend wrong!");
        }

    }
}
