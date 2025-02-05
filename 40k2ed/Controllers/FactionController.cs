using _40k2ed.Data;
using Microsoft.AspNetCore.Mvc;
using _40k2ed.Models.EntityModels;
using _40k2ed.Models.ViewModels;

namespace _40k2ed.Controllers
{
    public class FactionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FactionController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Faction> factions = _db.Faction.ToList();
            return View(factions);
        }
        public IActionResult FactionUnits(int factionId)
        {
            var faction = _db.Faction.Find(factionId);
            if (faction == null)
            {
                return NotFound();
            }
            var factionCategories = _db.FactionCategory
                .Where(fc => fc.FactionId == factionId)
                .ToList();
            var factionUnits = new FactionUnits
            {
                Faction = faction,
                FactionCategoriesUnitLists = new List<FactionCategoryUnitList>()
            };

            foreach (FactionCategory factionCategory in factionCategories)
            {
                var unit = _db.Unit
                    .Where(unit => unit.FactionCategoryId == factionCategory.FactionCategoryId)
                    .ToList();
                var factionCategoryUnitList = new FactionCategoryUnitList
                {
                    FactionCategory = factionCategory,
                    Units = unit
                };
                factionUnits.FactionCategoriesUnitLists.Add(factionCategoryUnitList);
            }          

            return View(factionUnits);
        }

    }
}
