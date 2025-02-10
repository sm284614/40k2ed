using _40k2ed.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using _40k2ed.Data;

namespace _40k2ed.Controllers
{
    public class UnitController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UnitController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int unitId)
        {
            var unit = _db.Unit
                .Where(u => u.UnitId == unitId)
                .FirstOrDefault();
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }
    }
}
