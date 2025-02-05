using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _40k2ed.Models.DataTable
{
    public class Faction
    {
        [Key]
        public int FactionId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public byte StrategyRating { get; set; } = 0;
        public string? Source { get; set; } = "";
        [Column("AlliesOnly")]
        public bool AlliesOnly { get; set; } = false;
    }
}
