namespace IntegratedSystemsExamAdmin.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string? Embg { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<Vaccine>? VaccinationSchedule { get; set; }
    }
}
