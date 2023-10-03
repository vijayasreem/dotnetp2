
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<int>> CreateLoanApprovalModelAsync(LoanApprovalModel loanApprovalModel)
        {
            var id = await _loanApprovalModelService.CreateLoanApprovalModelAsync(loanApprovalModel);
            return id;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanApprovalModel>> GetLoanApprovalModelAsync(int id)
        {
            var loanApprovalModel = await _loanApprovalModelService.GetLoanApprovalModelAsync(id);
            if (loanApprovalModel == null)
            {
                return NotFound();
            }
            return loanApprovalModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<LoanApprovalModel>>> GetAllLoanApprovalModelsAsync()
        {
            var loanApprovalModels = await _loanApprovalModelService.GetAllLoanApprovalModelsAsync();
            return loanApprovalModels;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoanApprovalModelAsync(int id, LoanApprovalModel loanApprovalModel)
        {
            if (id != loanApprovalModel.Id)
            {
                return BadRequest();
            }
            
            await _loanApprovalModelService.UpdateLoanApprovalModelAsync(loanApprovalModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanApprovalModelAsync(int id)
        {
            await _loanApprovalModelService.DeleteLoanApprovalModelAsync(id);
            return NoContent();
        }
    }
}
