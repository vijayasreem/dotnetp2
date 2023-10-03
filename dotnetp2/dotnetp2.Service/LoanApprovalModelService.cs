using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DataAccess;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public class LoanApprovalModelService : ILoanApprovalModelService
    {
        private readonly ILoanApprovalModelRepository _repository;

        public LoanApprovalModelService(ILoanApprovalModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateLoanApprovalModel(LoanApprovalModel loanApprovalModel)
        {
            return await _repository.CreateLoanApprovalModel(loanApprovalModel);
        }

        public async Task<LoanApprovalModel> GetLoanApprovalModel(int id)
        {
            return await _repository.GetLoanApprovalModel(id);
        }

        public async Task<List<LoanApprovalModel>> GetAllLoanApprovalModels()
        {
            return await _repository.GetAllLoanApprovalModels();
        }

        public async Task UpdateLoanApprovalModel(LoanApprovalModel loanApprovalModel)
        {
            await _repository.UpdateLoanApprovalModel(loanApprovalModel);
        }

        public async Task DeleteLoanApprovalModel(int id)
        {
            await _repository.DeleteLoanApprovalModel(id);
        }
    }
}