namespace Challenge.TOTVS.Domain.ViewModel
{
    public class CandidateVM
    {
        public Guid UserId { get; set; }  = Guid.NewGuid();
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = default!;

        public DateTime Birthday { get; set; }

        public string FilePath { get; set; } = default!;
    }
}
