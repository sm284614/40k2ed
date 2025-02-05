namespace _40k2ed.Models.DataTable
{
    public class UnitModel
    {
        public int UnitModelId { get; set; }
        public int UnitId { get; set; }
        public int ModelId { get; set; }
        public string DisplayName { get; set; }
        public int SquadOrder { get; set; }
        public int DefaultQuantity { get; set; }
        public int MinimumQuantity { get; set; }
        public int MaximumQuantity { get; set; }
        public bool MainModel { get; set; }
        public int Cost { get; set; }
        public int FactionCategoryId { get; set; }
        public bool VisibleInListing { get; set; }
        public int UnitModelIdToReplace { get; set; } //e.g. if veteran sergeant,id of sergeant goes here: remove id when this added, add id when this removed
    }
}
