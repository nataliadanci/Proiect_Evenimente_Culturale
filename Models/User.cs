using System.ComponentModel.DataAnnotations;

namespace Proiect_MP1.Models
{
    public class User
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Prenumele trebuie sa inceapa cu majuscula")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Prenume")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Numele trebuie sa inceapa cu majuscula")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Nume")]
        public string? LastName { get; set; }
        public string Email { get; set; }

        [RegularExpression(@"^0([0-9]{3})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
        ErrorMessage = "Telefonul trebuie să fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' și să înceapă cu cifra 0")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Nume complet")]
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
