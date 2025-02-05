namespace _40k2ed.Models.DataTable
{
    public class FactionCategory
    {
        public int FactionCategoryId { get; set; }
        public int FactionId { get; set; }
        public string Name { get; set; }
        public float AllowangeMinimumPercentage { get; set; }
        public float AllowangeMaximumPercentage { get; set; }
    }
}
