namespace _40k2ed.Models.DataTable
{
    public class UnitModelWargear
    {
        public int UnitModelWargearId { get; set; }
        public int UnitModelId { get; set; }
        public int WargearItemId { get; set; }
        public string WargearType { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
    }
}
