namespace _40k2ed.Models.EntityModels
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ModelsMinimum { get; set; }
        public int ModelsMaximum { get; set; }
        public int ArmyMinimum { get; set; }
        public int ArmyMaximum { get; set; }
        public int FactionCategoryId { get; set; }
        public int CodexOrder { get; set; }
        public int Cost { get; set; }
    }
}
