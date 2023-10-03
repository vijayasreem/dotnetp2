public interface ILoanApprovalModelService
{
    Task<int> CreateLoanApprovalModel(LoanApprovalModel loanApprovalModel);
    Task<LoanApprovalModel> GetLoanApprovalModel(int id);
    Task<List<LoanApprovalModel>> GetAllLoanApprovalModels();
    Task UpdateLoanApprovalModel(LoanApprovalModel loanApprovalModel);
    Task DeleteLoanApprovalModel(int id);
}