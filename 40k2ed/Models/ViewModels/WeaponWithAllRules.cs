using _40k2ed.Models.EntityModels;

namespace _40k2ed.Models.DisplayModels
{
    public class WeaponWithAllRules
    {
        public Weapon Weapon { get; set; }
        public List<WeaponRule> SpecialRules { get; set; }
    }
}
