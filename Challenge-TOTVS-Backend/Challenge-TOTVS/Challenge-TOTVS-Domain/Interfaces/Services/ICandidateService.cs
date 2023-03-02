using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface ICandidateService //: IBaseService<Candidate>
    {
        Task Add(Candidate obj);
        Candidate GetById(int id);
        IEnumerable<Candidate> GetAll();
        Task Update(Candidate obj);
        Task Remove(Candidate obj);
    }
}
