namespace Proiect_MP1.Models
{
    public class EventData
    {
        public IEnumerable<Eveniment> Evenimente { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<EventCategory> EventCategories { get; set; }
    }
}
