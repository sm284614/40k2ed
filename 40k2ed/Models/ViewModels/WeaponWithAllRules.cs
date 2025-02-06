using _40k2ed.Models.EntityModels;

namespace _40k2ed.Models.DisplayModels
{
    public class WeaponWithAllRules
    {        
        public Weapon Weapon { get; set; } = new Weapon();
        public List<WeaponRule> SpecialRules { get; set; } = new List<WeaponRule>();
    }
}
