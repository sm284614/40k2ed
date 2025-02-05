namespace _40k2ed.Models.EntityModels
{
    public class UnitModelWargearListAllowance
    {
        public long UnitModelWargearListAllowanceId { get; set; }
        public long UnitModelId { get; set; }
        public long WargearListId { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
    }
}
