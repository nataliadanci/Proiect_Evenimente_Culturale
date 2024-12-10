using System.Security.Policy;

namespace Proiect_MP1.Models.ViewModels
{
    public class EventPlannerIndexData
    {
        public IEnumerable<EventPlanner> EventPlanners { get; set; }
        public IEnumerable<Eveniment> Evenimente { get; set; }

    }
}
