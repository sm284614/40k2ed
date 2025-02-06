namespace _40k2ed.Models.ViewModels
{
    public class ArmyViewModel
    {
        public long ArmyID { get; set; }
        public int FactionId { get; set; }
        public string FactionName { get; set; } = ""; // For displaying the faction name
        public string Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public int PointsLimit { get; set; }
        public DateTime DateCreated { get; set; }

    }

}
