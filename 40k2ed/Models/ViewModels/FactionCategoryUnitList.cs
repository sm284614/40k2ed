using _40k2ed.Models.EntityModels;

namespace _40k2ed.Models.ViewModels
{
    public class FactionCategoryUnitList
    {
        public FactionCategory FactionCategory { get; set; }
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
}
