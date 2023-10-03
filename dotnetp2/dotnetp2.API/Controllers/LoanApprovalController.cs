
using Microsoft.AspNetCore.Mvc;
using dotnetp2.DTO;
using dotnetp2.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetp2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApprovalController : ControllerBase
    {
        private readonly ILoanApprovalModelService _loanApprovalModelService;

        public LoanApprovalController(ILoanApprovalModelService loanApprovalModelService)
        {
            _loanApprovalModelService = loanApprovalModelService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateLoanApprovalModel(LoanApprovalModel loanApprovalModel)
        {
            var id = await _loanApprovalModelService.CreateLoanApprovalModel(loanApprovalModel);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanApprovalModel>> GetLoanApprovalModel(int id)
        {
            var loanApprovalModel = await _loanApprovalModelService.GetLoanApprovalModel(id);
            
            if (loanApprovalModel == null)
            {
                return NotFound();
            }
            
            return Ok(loanApprovalModel);
        }

        [HttpGet]
        public async Task<ActionResult<List<LoanApprovalModel>>> GetAllLoanApprovalModels()
        {
            var loanApprovalModels = await _loanApprovalModelService.GetAllLoanApprovalModels();
            return Ok(loanApprovalModels);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLoanApprovalModel(LoanApprovalModel loanApprovalModel)
        {
            await _loanApprovalModelService.UpdateLoanApprovalModel(loanApprovalModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanApprovalModel(int id)
        {
            await _loanApprovalModelService.DeleteLoanApprovalModel(id);
            return NoContent();
        }
    }
}
