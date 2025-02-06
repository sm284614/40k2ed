namespace _40k2ed.Models.EntityModels
{
    public class Army
    {
        public long ArmyID { get; set; }
        public string UserId { get; set; } = "";
        public int FactionId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public int PointsLimit { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
