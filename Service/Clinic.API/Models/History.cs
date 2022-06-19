namespace Clinic.API.Models
{
    public class History : BaseEntity
    {        
        public DateTime UpdatedAt { get; set; }
        public int ClinicId { get; set; }
        //public Clinic Clinic { get; set; }
    }
}
