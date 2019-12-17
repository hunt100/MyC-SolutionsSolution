using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication1.Areas.Identity.Data;

namespace MyWebApplication1.Areas.Controllers
{
    [Authorize]
    public class IdentityUserController : Controller
    {
        private readonly MyWebApplication1IdentityDbContext _secContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
            
        public IdentityUserController(MyWebApplication1IdentityDbContext secContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _secContext = secContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            bool isExist = await _roleManager.RoleExistsAsync("Role_amidn");
            if (!isExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("Role_amidn"));
            }

            if (User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                IdentityUser user = _secContext.Users.Find(currentUserID);
                await _userManager.AddToRoleAsync(user, "Role_amidn");
                await _signInManager.RefreshSignInAsync(user);
            }
            
            
            if (User.Identity.IsAuthenticated)
            {
                Console.WriteLine("------------------" +_secContext.Users.FirstOrDefault().UserName);
            }
            Console.WriteLine("---------------------------------------------------");
            return View();
        }
    }
}