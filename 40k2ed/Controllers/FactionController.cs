using _40k2ed.Data;
using Microsoft.AspNetCore.Mvc;
using _40k2ed.Models.DataTable;

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
        public IActionResult FactionUnit(int factionId)
        {
            var units = _db.Unit
                .Join(_db.FactionUnit, u => u.UnitId, fu => fu.UnitId, (u, fu) => new { Unit = u, FactionUnit = fu })
                .Where(u => u.FactionUnit.FactionId == factionId);

            return View();
        }
    }
}
