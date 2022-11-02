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

namespace MyProject.Controllers
{
    [Authorize]
    public class OwnersController : Controller
    {
        private readonly MyProjectContext _context;
        private readonly ApplicationDbContext _userContext;

        public OwnersController(MyProjectContext context, ApplicationDbContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        // GET: Owners
        public async Task<IActionResult> Index()
        {
            var users = await _userContext.User.ToListAsync();
            var owners = await _context.Owner.ToListAsync();

            var ownerViewModels = owners.Select(item => new OwnerViewModel(item, users, null));

            return View(ownerViewModels);
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Owner == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            var users = await _userContext.User.ToListAsync();
            var ownerViewModel = new OwnerViewModel(owner, users, null);

            return View(ownerViewModel);
        }

        // GET: Owners/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string relationship, string idNumber, string telephone, string phone, string residence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Owner() { Name = name, Relationship = relationship, IdNumber = idNumber, Telephone = telephone, Phone = phone, Residence = residence, CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier), CreateTime = DateTime.Now });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(owner);
            return RedirectToAction(nameof(Index));
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Owner == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Relationship,IdNumber,Telephone,Phone,Residence,CreateTime,CreateId")] Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    owner.UpdateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    owner.UpdateTime = DateTime.Now;
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.Id))
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
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Owner == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            //var house = await _context.House.FirstOrDefaultAsync(h => h.OwnerId == id);
            //if (house is not null)
            //    return Page();

            var users = await _userContext.User.ToListAsync();
            var ownerViewModel = new OwnerViewModel(owner, users, null);

            return View(ownerViewModel);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Owner == null)
            {
                return Problem("Entity set 'MyProjectContext.Owner'  is null.");
            }
            var owner = await _context.Owner.FindAsync(id);
            if (owner != null)
            {
                var house = await _context.House.FirstOrDefaultAsync(h => h.OwnerId == id);
                if (house is not null)
                {
                    var users = await _userContext.User.ToListAsync();
                    var ownerViewModel = new OwnerViewModel(owner, users, "請先修改或移除和此所有權人有關的客戶資料");
                    return View("Delete", ownerViewModel);
                }

                _context.Owner.Remove(owner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int id)
        {
          return (_context.Owner?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
