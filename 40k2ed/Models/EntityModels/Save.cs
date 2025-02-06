namespace _40k2ed.Models.EntityModels
{
    public class Save
    {
        public int SaveId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = ""; 
        public string Roll { get; set; } = "";
        public bool Modifiable { get; set; }
        public int NumberOfDice { get; set; }
        public string SpecialRules { get; set; } = "";
        public int SaveTypeId { get; set; }
    }
}
