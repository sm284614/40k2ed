namespace _40k2ed.Models.EntityModels
{
    public class Army
    {
        public int ArmyID { get; set; }
        public int UserId { get; set; }
        public int FactionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointsLimit { get; set; }
        public DateOnly DateCreated { get; set; }
    }
}
