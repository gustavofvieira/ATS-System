using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Challenge.TOTVS.Domain.Interfaces.Repositories
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        void UploadCVFile(IFormFile formFile);
    }
}
