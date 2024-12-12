using System.ComponentModel.DataAnnotations;

namespace Proiect_MP1.Models
{
    public class User
    {
        public int ID { get; set; }

        [Display(Name = "Prenume")]
        public string? FirstName { get; set; }

        [Display(Name = "Nume")]
        public string? LastName { get; set; }
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Listă înregistrări")]
        public ICollection<Registration>? Registrations { get; set; }
    }
}
