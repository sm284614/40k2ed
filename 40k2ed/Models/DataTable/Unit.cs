namespace _40k2ed.Models.DataTable
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int ModelsMinimum { get; set; }
        public int ModelsMaximum { get; set; }
        public int MinimumPerArmy { get; set; }
        public int MaximumPerArmy { get; set; }
    }
}
