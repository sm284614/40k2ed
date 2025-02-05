using _40k2ed.Models.DataTable;

namespace _40k2ed.Models.Display
{
    public class WeaponWithAllRules
    {
        public Weapon Weapon { get; set; }
        public List<WeaponRule> SpecialRules { get; set; }
    }
}
