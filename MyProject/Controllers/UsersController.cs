using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Migrations;
using MyProject.Models;
using MyProject.ViewModels;
using System.Security.Claims;

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
            var users = await _userContext.User.ToListAsync();
            var userRoles = await _userContext.UserRoles.ToListAsync();
            var roles = await _userContext.Roles.ToListAsync();
            var departments = await _context.Department.ToListAsync();

            var userViewModels = users.Select(
                item => new UserViewModel(
                    item,
                    users,
                    item.DepartmentId is not null ? departments.FirstOrDefault(d => d.Id == item.DepartmentId)?.Name : null,
                    userRoles.FirstOrDefault(ur => ur.UserId == item.Id) is not null ? roles.FirstOrDefault(r => r.Id == userRoles.FirstOrDefault(ur => ur.UserId == item.Id)?.RoleId).Name : null
                )
            );

            return userViewModels != null ?
                          View(userViewModels) :
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
            var user = await _userContext.User.FindAsync(id);
            var users = await _userContext.User.ToListAsync();
            var userRoleList = await _userManager.GetRolesAsync(user);
            ViewBag.Roles = await _userContext.Roles.ToListAsync();
            ViewBag.Departments = await _context.Department.ToListAsync();

            var userViewModel = new UserViewModel(
                user,
                users,
                null,
                userRoleList.Count > 0 ? userRoleList[0] : null
            );

            return View(userViewModel);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, UserName, CnName, DepartmentId, CreateTime, CreateId")] ApplicationUser item, string? roleName)
        {
            var user = await _userContext.User.FirstOrDefaultAsync(x => x.Id == item.Id);
            user.UserName = item.UserName;
            user.NormalizedUserName = item.UserName.ToUpper();
            user.CnName = item.CnName;
            user.DepartmentId = item.DepartmentId;
            user.CreateTime = item.CreateTime;
            user.CreateId = item.CreateId;
            user.UpdateTime = DateTime.Now;
            user.UpdateId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                try
                {
                    _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user)).Wait();

                    if (roleName is not null)
                        _userManager.AddToRoleAsync(user, roleName).Wait();

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

            var users = await _userContext.User.ToListAsync();
            var userRoleList = await _userManager.GetRolesAsync(user);
            var departments = await _context.Department.ToListAsync();

            var userViewModel = new UserViewModel(
                user,
                users,
                user.DepartmentId is not null ? departments.FirstOrDefault(y => y.Id == user.DepartmentId)?.Name : null,
                userRoleList.Count > 0 ? userRoleList[0] : null
            );

            return View(userViewModel);
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
                _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user)).Wait();
                user.UpdateTime = DateTime.Now;
                user.UpdateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
