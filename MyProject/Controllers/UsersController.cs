using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    [Authorize(Roles = "管理者")]
    public class UsersController : Controller
    {
        private readonly MyProjectContext _context;
        private readonly ApplicationDbContext _userContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(MyProjectContext context, ApplicationDbContext userContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userContext = userContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var userIndexList = new List<UserIndexViewModel>();

            var users = await _userContext.User.ToListAsync();
            var userRoles = await _userContext.UserRoles.ToListAsync();
            var roles = await _userContext.Roles.ToListAsync();
            var departments = await _context.Department.ToListAsync();

            userIndexList = users.Select(x => new UserIndexViewModel
            {
                UserId = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                CnName = x.CnName,
                EngName = x.EngName,
                DepartmentName = x.DepartmentId is not null ? departments.FirstOrDefault(y => y.Id == x.DepartmentId).Name : null,
                RoleName = userRoles.FirstOrDefault(y => y.UserId == x.Id) is not null ? roles.FirstOrDefault(z => z.Id == userRoles.FirstOrDefault(y => y.UserId == x.Id).RoleId).Name : null
            }).ToList();

            return userIndexList != null ?
                          View(userIndexList) :
                          Problem("Entity set 'MyProjectContext.House'  is null.");
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var userIndex = new UserEditViewModel();

            var user = await _userContext.User.FindAsync(id);
            //var userRoles = await _userContext.UserRoles.ToListAsync();
            var roles = await _userContext.Roles.ToListAsync();
            ViewBag.Roles = roles;

            var departments = await _context.Department.ToListAsync();
            ViewBag.Departments = departments;

            //var userRoleList = await _userManager.GetRolesAsync(user);
            var userRoleList = new string[]
            {
                "組長"
            };

            userIndex = new UserEditViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                CnName = user.CnName,
                //DepartmentName = departments.FirstOrDefault(y => y.Id == user.DepartmentId).Name,
                //RoleName = roles.FirstOrDefault(y => y.Id == userRoles.FirstOrDefault(z => z.UserId == user.Id).RoleId).Name
                DepartmentId = user.DepartmentId,
                RoleName = userRoleList[0]
            };

            return View(userIndex);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId, UserName, CnName, DepartmentId, RoleName")] UserEditViewModel item)
        {
            var user = await _userContext.User.FirstOrDefaultAsync(x => x.Id == id);

            user.CnName = item.CnName;
            user.DepartmentId = item.DepartmentId;
            user.UserName = item.UserName;

            if (ModelState.IsValid)
            {
                try
                {
                    _userManager.AddToRoleAsync(user, item.RoleName).Wait();
                    await _userContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            //return View();
            return null;
        }

        // POST: UserController/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _userContext.Users == null)
            {
                return NotFound();
            }

            var user = await _userContext.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_userContext.Users == null)
            {
                return Problem("");
            }
            var user = await _userContext.Users.FindAsync(id);
            if (user != null)
            {
                _userManager.RemoveFromRolesAsync(user, new List<string>() { "組長", "員工", "祕書" }).Wait();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
