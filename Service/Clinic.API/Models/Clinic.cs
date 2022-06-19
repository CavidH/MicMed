namespace Clinic.API.Models
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public ICollection<History> Historys { get; set; }
        //public ICollection<AppUser> AppUsers { get; set; }
    }
}
