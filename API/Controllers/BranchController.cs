using API.Helper;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Responses;
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
            {
                List<string> errors = ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToList();
                string errorMessage = string.Join(";", errors);
                return BadRequest(BranchResponse.ErrorResponse(errorMessage));
            }

            Branch branch = this._mapper.Map<Branch>(branchDto);
            

            Branch result = await this._context.Add(branch);

            if (result != null)
                return Ok(BranchResponse.SuccessResponse("Branch Created Successfully!", result.ID));
            else
                return BadRequest(BranchResponse.ErrorResponse("Something wend wrong!"));
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
        [Route("Get/{serial}")]
        public async Task<ActionResult<BranchDto>> GetBySerial(string serial)
        {
            BranchDto branch = _mapper.Map<BranchDto>(await _context.GetBySerialAsync(serial));
            if(branch == null)
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
        
        [HttpGet]
        [Route("GetByStoreSerial/{storeSerial}")]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetAllByStore(string storeSerial)
        {
            IEnumerable<Branch> branches = await _context.GetAllByStoreSerial(storeSerial);
            if (branches.Count() == 0)
                return BadRequest(GeneralResponse<BranchDto>.ErrorResponse("No Branches found"));

            IEnumerable<BranchDto> branchsDto = _mapper.Map<IEnumerable<BranchDto>>(branches);
            
            return Ok(GeneralResponse<BranchDto>.SuccessResponse(branchsDto));

        }



    }
}
