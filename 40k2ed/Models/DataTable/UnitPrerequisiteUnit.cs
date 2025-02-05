namespace _40k2ed.Models.DataTable
{
    public class UnitPrerequisiteUnit
    {
        public int UnitPrerequisiteUnitId { get; set; }
        public int UnitId { get; set; }
        public int PrerequisiteUnitId { get; set; }
        public int QuantityAllowedPerPrequisiteUnit { get; set; }
    }
}
