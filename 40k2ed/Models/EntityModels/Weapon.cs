namespace _40k2ed.Models.EntityModels
{
    public class Weapon
    {
        public int WeaponId { get; set; }
        public string Name { get; set; } = "[no name]";
        public int WeaponTypeId { get; set; }
        public string? Description { get; set; }
        public string? ShortRangeStart { get; set; }
        public string? ShortRangeEnd { get; set; }
        public string? LongRangeStart { get; set; }
        public string? LongRangeEnd { get; set; }
        public string? ToHitShort { get; set; }
        public string? ToHitLong { get; set; }
        public string? Strength { get; set; }
        public string? Damage { get; set; }
        public string? SaveModifier { get; set; }
        public string? ArmourPenetration { get; set; }
        //public string? SpeicalRulesList { get; set; }
    }
}
