namespace _40k2ed.Models.DataTable
{
    public class ArmyUnit
    {
        public long ArmyUnitId { get; set; }
        public int ArmyId { get; set; }
        public int UnitId { get; set; }
        //duplicated here to more easily calculate category limits
        public int FactionCategoryId { get; set; }
    }
}
