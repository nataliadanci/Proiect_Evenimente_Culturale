using System.ComponentModel.DataAnnotations;

namespace Proiect_MP1.Models
{
    public class Category
    {
        public int ID { get; set; }   

        [Display(Name = "Categorie")]
        public string CategoryName { get; set; }
        public ICollection<EventCategory>? EventCategories { get; set; }
    }
}
