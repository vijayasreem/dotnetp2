public interface ILoanApprovalModelService
{
    Task<int> CreateLoanApprovalModelAsync(LoanApprovalModel loanApprovalModel);
    Task<LoanApprovalModel> GetLoanApprovalModelAsync(int id);
    Task<List<LoanApprovalModel>> GetAllLoanApprovalModelsAsync();
    Task UpdateLoanApprovalModelAsync(LoanApprovalModel loanApprovalModel);
    Task DeleteLoanApprovalModelAsync(int id);
}