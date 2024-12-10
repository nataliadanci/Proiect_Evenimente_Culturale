using System.ComponentModel.DataAnnotations;

namespace Proiect_MP1.Models
{
    public class Registration
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? EvenimentID { get; set; }
        public Eveniment? Eveniment { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}
