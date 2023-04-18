namespace Challenge.TOTVS.Domain.Models
{
    public class JobApplication
    {
        public Guid JobVacancyId { get; set; }
        public string Title { get; set; } = default!;
        public List<Candidate> Candidates { get; set; } = default!;

    }
}
