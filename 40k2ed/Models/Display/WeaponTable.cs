using _40k2ed.Models.DataTable;

namespace _40k2ed.Models.Display
{
    public class WeaponTable
    {
        public WeaponType WeaponType { get; set; }
        public List<WeaponWithAllRules> Weapons { get; set; }
    }
}
