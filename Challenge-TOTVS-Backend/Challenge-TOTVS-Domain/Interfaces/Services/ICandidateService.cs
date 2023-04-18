using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.ViewModel;
using Microsoft.AspNetCore.Http;

namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface ICandidateService : IBaseService<Candidate>
    {
        Task UploadCVFile(Guid id, IFormFile formFile);
        Task CreateCandidate(CandidateVM candidateVM);
    }
}
