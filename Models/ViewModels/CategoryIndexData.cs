using System.Security.Policy;

namespace Proiect_MP1.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Eveniment> Evenimente { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
