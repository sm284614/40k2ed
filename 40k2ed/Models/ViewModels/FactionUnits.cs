using _40k2ed.Models.EntityModels;

namespace _40k2ed.Models.ViewModels
{
    public class FactionUnits
    {
        public Faction Faction { get; set; }
        public List<FactionCategoryUnitList> FactionCategoriesUnitLists { get; set; } = new List<FactionCategoryUnitList>();
    }
}
