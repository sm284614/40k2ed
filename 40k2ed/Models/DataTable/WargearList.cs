namespace _40k2ed.Models.DataTable
{
    public class WargearList
    {
        public int WargearListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WargearType { get; set; }
        public int FactionId { get; set; }
        public int CodexOrder { get; set; }
        public bool AppliesToWholeUnit { get; set; }
        public bool HiddenFromMainList { get; set; }
    }
}
