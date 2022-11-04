using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Migrations;
using MyProject.Models;
using MyProject.ViewModels;
using Newtonsoft.Json;

namespace MyProject.Controllers
{
    [Authorize]
    public class HousesController : Controller
    {
        private readonly MyProjectContext _context;
        private readonly ApplicationDbContext _userContext;

        public HousesController(MyProjectContext context, ApplicationDbContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        // GET: Houses
        public async Task<IActionResult> Index()
        {
            //var houseViewModels = new List<HouseViewModel>();
            var users = await _userContext.User.ToListAsync();
            var owners = await _context.Owner.ToListAsync();

            if (User.IsInRole("管理者"))
            {
                var availableHouses = await _context.House.ToListAsync();

                var houseViewModels = availableHouses.Select(
                    item => new HouseViewModel(
                        item,
                        users,
                        item.OwnerId is not null ? owners.FirstOrDefault(o => o.Id == item.OwnerId) : null
                    )
                );

                return View(houseViewModels);
            }
            else
            {
                var houseUsersByUserId = await _context.HouseUser.Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
                var houses = await _context.House.ToListAsync();
                var availableHouses = houses.Where(x => houseUsersByUserId.FindIndex(y => y.HouseId == x.Id) != -1).ToList();
                var houseViewModels = availableHouses.Select(
                    item => new HouseViewModel(
                        item,
                        users,
                        item.OwnerId is not null ? owners.FirstOrDefault(o => o.Id == item.OwnerId) : null
                    )
                );

                return View(houseViewModels);
            }
        }

        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.House == null)
            {
                return NotFound();
            }

            var house = await _context.House.FirstOrDefaultAsync(m => m.Id == id);

            if (house == null)
            {
                return NotFound();
            }

            var users = await _userContext.User.ToListAsync();
            var owners = await _context.Owner.ToListAsync();
            var houseViewModel = new HouseViewModel(
                house,
                users,
                house.OwnerId is not null ? owners.FirstOrDefault(o => o.Id == house.OwnerId) : null
            );

            return View(houseViewModel);
        }

        // GET: Houses/Create
        [Authorize(Roles = "管理者")]
        public IActionResult Create()
        {
            var ownerItems = _context.Owner.ToList();
            var selectItems = ownerItems.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });

            ViewBag.OwnerItems = selectItems;

            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "管理者")]
        public async Task<IActionResult> Create([Bind("Id,City,Region,Section,Subsection,Number,RegisterReason,Order,Area,ShareNumerator,ShareDenominator,OwnerId,RegisterTime")] House house)
        {
            if (ModelState.IsValid)
            {
                house.CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                house.CreateTime = DateTime.Now;
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Edit/5
        [Authorize(Roles = "管理者")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.House == null)
            {
                return NotFound();
            }

            var house = await _context.House.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            var ownerItems = _context.Owner.ToList();
            var selectItems = ownerItems.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });

            ViewBag.OwnerItems = selectItems;

            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "管理者")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,Region,Section,Subsection,Number,RegisterReason,Order,Area,ShareNumerator,ShareDenominator,OwnerId,RegisterTime,CreateTime,CreateId")] House house)
        {
            if (id != house.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    house.UpdateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    house.UpdateTime = DateTime.Now;
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Delete/5
        [Authorize(Roles = "管理者")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.House == null)
            {
                return NotFound();
            }

            var house = await _context.House.FirstOrDefaultAsync(m => m.Id == id);

            if (house == null)
            {
                return NotFound();
            }

            var users = await _userContext.User.ToListAsync();
            var owners = await _context.Owner.ToListAsync();
            var houseViewModel = new HouseViewModel(
                house,
                users,
                house.OwnerId is not null ? owners.FirstOrDefault(o => o.Id == house.OwnerId) : null
            );

            return View(houseViewModel);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "管理者")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.House == null)
            {
                return Problem("Entity set 'MyProjectContext.House'  is null.");
            }
            var house = await _context.House.FindAsync(id);
            if (house != null)
            {
                _context.House.Remove(house);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: 
        [Authorize(Roles = "管理者")]
        public async Task<IActionResult> Access(int id, string ownerName)
        {
            TempData["HouseId"] = id;
            var houseAccessList = new List<HouseAccessViewModel>();

            var selectedUsers = await _context.HouseUser.Where(x => x.HouseId == id).ToListAsync();
            TempData["OldSelectedUsers"] = JsonConvert.SerializeObject(selectedUsers);

            var users = await _userContext.Users.ToListAsync();
            var departments = await _context.Department.ToListAsync();

            houseAccessList = users.Select(x => new HouseAccessViewModel {
                UserId = x.Id,
                UserName = x.UserName,
                CnName = x.CnName,
                EngName = x.EngName,
                DepartmentName = departments != null ? departments.FirstOrDefault(y => y.Id == x.DepartmentId)?.Name : null,
                Checked = selectedUsers.FindIndex(y => y.UserId == x.Id) != -1
            }).ToList();

            ViewBag.OwnerName = ownerName;

            return houseAccessList != null ?
                View(houseAccessList) :
                Problem("Entity set 'Users' is null.");
        }

        // GET: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "管理者")]
        public async Task<IActionResult> Access(string[] userIds)
        {
            var houseId = Convert.ToInt32(TempData["HouseId"]);
            var oldSelectedUsers = JsonConvert.DeserializeObject<List<HouseUser>>(TempData["OldSelectedUsers"].ToString());

            var userIdsToInsert = userIds is not null ? (
                oldSelectedUsers is not null ? (
                    userIds.Where(x => oldSelectedUsers.FindIndex(y => y.UserId == x) == -1).Select(x => new HouseUser { HouseId = houseId, UserId = x })
                ) : userIds.Select(x => new HouseUser { HouseId = houseId, UserId = x })
            ) : null;
            var userIdsToDelete = oldSelectedUsers is not null ? oldSelectedUsers.Where(x => !userIds.Contains(x.UserId)) : null;

            if (ModelState.IsValid)
            {
                try
                {
                    if (userIdsToDelete is not null)
                        _context.RemoveRange(userIdsToDelete);
                    if (userIdsToInsert is not null)
                        _context.AddRange(userIdsToInsert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool HouseExists(int id)
        {
            return (_context.House?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool HouseUserExists(int houseId, string userId)
        {
            return (_context.HouseUser?.Any(e => e.HouseId == houseId && e.UserId == userId)).GetValueOrDefault();
        }
    }
}
