using System.ComponentModel.DataAnnotations;

namespace Proiect_MP1.Models
{
    public class EventCategory
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public Eveniment Eveniment{ get; set; }

        [Display(Name = "Categorie")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
