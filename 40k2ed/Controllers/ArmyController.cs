using _40k2ed.Data;
using _40k2ed.Models;
using _40k2ed.Models.EntityModels;
using _40k2ed.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _40k2ed.Controllers
{
    [Authorize]
    public class ArmyController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ArmyController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            // Get the userId of the logged-in user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Or use _userManager to fetch the user if needed

            // Query to get armies with faction names
            var armies = await _db.Army
                .Where(a => a.UserId == userId)
                .Join(_db.Faction, army => army.FactionId, faction => faction.FactionId, (army, faction) => new ArmyViewModel
                {
                    ArmyID = army.ArmyID,
                    UserId = army.UserId,
                    Name = army.Name,
                    Description = army.Description,
                    PointsLimit = army.PointsLimit,
                    DateCreated = army.DateCreated,
                    FactionName = faction.Name, // Get the faction name here
                    FactionId = faction.FactionId,
                })
                .ToListAsync();

            return View(armies); // Pass the list of armies with faction names to the view
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            List<Faction> factions = _db.Faction
                .Where(f => f.Source == "Codex")
                .OrderBy(f => f.Name)
                .ToList();
            ViewBag.Factions = factions;
            return View(new ArmyViewModel()); // Pass an empty ViewModel
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ArmyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Factions = _db.Faction.ToList();
                return View(model); // Show form again with validation messages
            }

            // Get logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(); // Ensure the user is logged in
            }

            // Create Army entity
            var newArmy = new Army
            {
                UserId = user.Id, // Assign logged-in user ID
                FactionId = model.FactionId,
                Name = model.Name,
                Description = model.Description,
                PointsLimit = model.PointsLimit,
                DateCreated = DateTime.UtcNow
            };

            _db.Army.Add(newArmy);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirect to army list after creation
        }
        public async Task<IActionResult> Delete(long armyId)
        {
            // Get the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(); // Ensure user is logged in
            }

            // Find the army by ID
            var army = await _db.Army.FindAsync(armyId);
            if (army == null)
            {
                return NotFound();
            }

            // Ensure the army belongs to the logged-in user
            if (army.UserId != user.Id)
            {
                return Forbid(); // Prevent unauthorized deletion
            }

            // Remove the army from the database
            _db.Army.Remove(army);
            await _db.SaveChangesAsync();

            // Redirect back to the Army index page
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int armyId)
        {
            // Get the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(); // Ensure user is logged in
            }
            // Find the army by ID and include the faction name
            var army = await _db.Army
                .Where(a => a.ArmyID == armyId)
                .Join(_db.Faction,
                    army => army.FactionId,
                    faction => faction.FactionId,
                    (army, faction) => new ArmyViewModel
                    {
                        ArmyID = army.ArmyID,
                        UserId = army.UserId,
                        Name = army.Name,
                        Description = army.Description,
                        PointsLimit = army.PointsLimit,
                        DateCreated = army.DateCreated,
                        FactionName = faction.Name, // Get the faction name here
                        FactionId = faction.FactionId,
                    })
                .FirstOrDefaultAsync(); // Get a single item

            if (army == null)
            {
                return NotFound();
            }
            if (army.UserId != user.Id)
            {
                return Forbid(); // Prevent unauthorized access
            }
            //get faction units
            var factionCategories = _db.FactionCategory
               .Where(fc => fc.FactionId == army.FactionId)
               .ToList();
            var faction = _db.Faction.Find(army.FactionId);
            if (faction == null)
            {
                return NotFound();
            }
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
            ViewBag.FactionUnits = factionUnits;

            return View(army); // Pass the army details to the view
        }

    }
}
