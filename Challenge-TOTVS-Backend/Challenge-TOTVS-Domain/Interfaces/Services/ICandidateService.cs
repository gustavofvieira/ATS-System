using Challenge.TOTVS.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface ICandidateService : IBaseService<Candidate>
    {
        Task UploadCVFile(Guid id, IFormFile formFile);
    }
}
