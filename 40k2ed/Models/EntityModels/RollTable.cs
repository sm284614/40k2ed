namespace _40k2ed.Models.EntityModels
{
    public class RollTable
    {
        public int RollTableId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Dice { get; set; } = "D6";
        public string ResultTitle { get; set; } = "Result";
    }
}
