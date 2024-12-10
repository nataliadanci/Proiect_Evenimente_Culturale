using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_MP1.Data;
namespace Proiect_MP1.Models
{
    public class EventCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_MP1Context context,
        Eveniment Eveniment)
        {
            var allCategories = context.Category;
            var eventCategories = new HashSet<int>(
            Eveniment.EventCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = eventCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateEventCategories(Proiect_MP1Context context,
        string[] selectedCategories, Eveniment eventToUpdate)
        {
            if (selectedCategories == null)
            {
                eventToUpdate.EventCategories = new List<EventCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var eventCategories = new HashSet<int>
            (eventToUpdate.EventCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!eventCategories.Contains(cat.ID))
                    {
                        eventToUpdate.EventCategories.Add(
                        new EventCategory
                        {
                            EventID = eventToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (eventCategories.Contains(cat.ID))
                    {
                        EventCategory eventToRemove
                        = eventToUpdate
                        .EventCategories
                       .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(eventToRemove);
                    }
                }
            }
        }
    }
}
