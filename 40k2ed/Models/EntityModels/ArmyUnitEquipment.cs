namespace _40k2ed.Models.EntityModels
{
    public class ArmyUnitEquipment
    {
        public long ArmyUnitEquipmentId { get; set; }
        public long ArmyUnitId { get; set; }
        public string EquipmentType { get; set; } = "";
    }
}
