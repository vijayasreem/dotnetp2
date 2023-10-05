using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface ISendEmailRepository
    {
        Task<SendEmailModel> GetSendEmailModelAsync(int id);
        Task<bool> SendEmailAsync(SendEmailModel model);
        Task<bool> SendFilesToFTPAsync(SendEmailModel model);
        Task<bool> SendFilesToSharepointAsync(SendEmailModel model);
    }
}