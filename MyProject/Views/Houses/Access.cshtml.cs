using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Views.Houses
{
    public class AccessModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccessModel
            (
            UserManager<IdentityUser> userManager
            )
        {
            _userManager = userManager;
        }

        [BindProperty]
        public IList<UserRolesViewModel> model { get; set; } = new List<UserRolesViewModel>();

        public class UserRolesViewModel
        {
            public string? UserName { get; set; }
        }


        //public void OnGet()
        //{
        //}
        public async Task<IActionResult> OnGetAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            foreach (IdentityUser user in users)
            {
                UserRolesViewModel urv = new UserRolesViewModel()
                {
                    UserName = user.UserName
                };

                model.Add(urv);
            }
            return Page();
        }
    }
}
