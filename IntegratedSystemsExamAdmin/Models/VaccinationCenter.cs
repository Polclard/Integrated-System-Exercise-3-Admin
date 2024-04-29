namespace IntegratedSystemsExamAdmin.Models
{
    public class VaccinationCenter
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int MaxCapacity { get; set; }
        public virtual ICollection<Vaccine>? Vaccines { get; set; }
    }
}
