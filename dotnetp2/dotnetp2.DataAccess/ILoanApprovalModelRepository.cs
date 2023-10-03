


using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface ILoanApprovalModelRepository
    {
        Task<int> CreateLoanApprovalModel(LoanApprovalModel loanApprovalModel);
        Task<LoanApprovalModel> GetLoanApprovalModel(int id);
        Task<List<LoanApprovalModel>> GetAllLoanApprovalModels();
        Task UpdateLoanApprovalModel(LoanApprovalModel loanApprovalModel);
        Task DeleteLoanApprovalModel(int id);
    }
}
