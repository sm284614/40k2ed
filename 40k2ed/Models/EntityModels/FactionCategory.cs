namespace _40k2ed.Models.EntityModels
{
    public class FactionCategory
    {
        public int FactionCategoryId { get; set; }
        public int FactionId { get; set; }
        public string Name { get; set; } = "";
        public double AllowanceMinimum { get; set; }
        public double AllowanceMaximum { get; set; }
    }
}
