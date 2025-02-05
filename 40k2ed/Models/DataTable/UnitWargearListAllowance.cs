namespace _40k2ed.Models.DataTable
{
    public class UnitWargearListAllowance
    {
        public long UnitWargearListAllowanceId { get; set; }
        public long UnitId { get; set; }
        public long WargearListId { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
    }
}
