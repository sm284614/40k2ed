using _40k2ed.Models.EntityModels;

namespace _40k2ed.Models.DisplayModels
{
    public class WeaponTable
    {
        public WeaponType WeaponType { get; set; }
        public List<WeaponWithAllRules> Weapons { get; set; }
    }
}
