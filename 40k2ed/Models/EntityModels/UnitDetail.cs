namespace _40k2ed.Models.EntityModels
{
    public class UnitDetail
    {
        public int UnitDetailId { get; set; }
        public int UnitId { get; set; }
        public string SectionName { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
