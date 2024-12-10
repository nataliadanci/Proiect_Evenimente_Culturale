using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_MP1.Models
{
    public class Eveniment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Adaugă numele evenimentului.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Numele evenimentului trebuie să aibă între 3 și 150 de caractere.")]
        [Display(Name = "Nume eveniment")]
        public string Nume { get; set; }
        public string Descriere { get; set; }

        [Display(Name = "Locație")]
        public string Locatie { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Începe")]
        public DateTime DataInceput { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Se termină")]
        public DateTime DataSfarsit { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Preț bilet")]
        public decimal Pret { get; set; }

        [Display(Name = "Categorie")]
        public int? EventPlannerID { get; set; }
        [Display(Name = "Organizator")]
        public EventPlanner? EventPlanner { get; set; }
        public ICollection<EventCategory>? EventCategories { get; set; }
        public ICollection<Registration>? Registrations { get; set; }

    }
}

