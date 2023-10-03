using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DataAccess;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public class LoanApprovalModelService : ILoanApprovalModelService
    {
        private readonly ILoanApprovalModelDataAccess _loanApprovalModelDataAccess;

        public LoanApprovalModelService(ILoanApprovalModelDataAccess loanApprovalModelDataAccess)
        {
            _loanApprovalModelDataAccess = loanApprovalModelDataAccess;
        }

        public async Task<int> CreateLoanApprovalModelAsync(LoanApprovalModel loanApprovalModel)
        {
            return await _loanApprovalModelDataAccess.CreateLoanApprovalModelAsync(loanApprovalModel);
        }

        public async Task<LoanApprovalModel> GetLoanApprovalModelAsync(int id)
        {
            return await _loanApprovalModelDataAccess.GetLoanApprovalModelAsync(id);
        }

        public async Task<List<LoanApprovalModel>> GetAllLoanApprovalModelsAsync()
        {
            return await _loanApprovalModelDataAccess.GetAllLoanApprovalModelsAsync();
        }

        public async Task UpdateLoanApprovalModelAsync(LoanApprovalModel loanApprovalModel)
        {
            await _loanApprovalModelDataAccess.UpdateLoanApprovalModelAsync(loanApprovalModel);
        }

        public async Task DeleteLoanApprovalModelAsync(int id)
        {
            await _loanApprovalModelDataAccess.DeleteLoanApprovalModelAsync(id);
        }
    }
}