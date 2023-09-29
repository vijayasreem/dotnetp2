
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface IDocumentVerificationRepository
    {
        Task<DocumentVerificationModel> GetById(int id);
        Task<IEnumerable<DocumentVerificationModel>> GetAll();
        Task<int> Create(DocumentVerificationModel model);
        Task<bool> Update(DocumentVerificationModel model);
        Task<bool> Delete(int id);
    }
}
