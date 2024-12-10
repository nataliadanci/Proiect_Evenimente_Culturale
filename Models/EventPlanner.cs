using System.ComponentModel.DataAnnotations;

namespace Proiect_MP1.Models
{
    public class EventPlanner
    {   
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Eveniment> Evenimente { get; set; }

        [Display(Name = "Organizator")]
        public string EventPlannerName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
