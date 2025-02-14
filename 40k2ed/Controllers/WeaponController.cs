﻿using Microsoft.AspNetCore.Mvc;
using _40k2ed.Data;
using _40k2ed.Models.EntityModels;
using Microsoft.AspNetCore.Authorization;

namespace _40k2ed.Controllers
{
    public class WeaponController : Controller
    {
        private readonly ApplicationDbContext _db;
        public WeaponController(ApplicationDbContext db)
        {
            _db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<WeaponType> weaponTypes = _db.WeaponType.ToList();
            return View(weaponTypes);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WeaponTable(int weaponTypeId)
        {
            // First query: get the WeaponType and list of Weapons
            var weaponType = _db.WeaponType
                                .Where(wt => wt.WeaponTypeId == weaponTypeId)
                                .FirstOrDefault();

            if (weaponType == null)
            {
                return NotFound();
            }

            var weapons = _db.Weapon
                             .Where(w => w.WeaponTypeId == weaponTypeId)
                             .ToList();

            // Second query: get the WeaponRules associated with each weapon
            var weaponRules = _db.WeaponWeaponRule
                                  .Where(wr => weapons.Select(w => w.WeaponId).Contains(wr.WeaponId))
                                  .Join(_db.WeaponRule, wr => wr.WeaponRuleId, wrule => wrule.WeaponRuleId, (wr, wrule) => new { wr.WeaponId, Rule = wrule })
                                  .ToList();

            // Construct the WeaponTable with Weapons and their Rules
            var weaponTable = new Models.DisplayModels.WeaponTable
            {
                WeaponType = weaponType,
                Weapons = weapons.Select(w => new Models.DisplayModels.WeaponWithAllRules
                {
                    Weapon = w,
                    SpecialRules = weaponRules.Where(wr => wr.WeaponId == w.WeaponId).Select(wr => wr.Rule).ToList()
                }).ToList()
            };

            return PartialView("_WeaponTable", weaponTable);

            //return View(weaponTable);
        }

        public IActionResult Detail(int weaponId)
        {
            return View();
        }

    }
}
