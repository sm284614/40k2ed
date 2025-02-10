using _40k2ed.Models.EntityModels;

namespace _40k2ed.Models.ViewModels
{
    public class ArmyUnitViewModel
    {
        public long ArmyUnitId { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; } = "";
        public int FactionCategoryId { get; set; }
        public List<ArmyUnitEquipment> Equipment { get; set; } = new List<ArmyUnitEquipment>();
        public List<ArmyUnitModel> Models { get; set; } = new List<ArmyUnitModel>();
    }
}
