using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static ECommerceApp.Web.App_Start.IdentityConfig;

namespace ECommerceApp.Web.Controllers
{
    [Authorize]
    public class UserRoleController : Controller
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;
        public UserRoleController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserRole
        public async Task<ActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        public async Task<ActionResult> Create(string userId)
        {
            //Get the list of Roles
            ViewBag.RoleId = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name");
            return View(model: userId);
        }

        //
        // POST: /Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(string UserId, string RoleId)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(RoleId))
                {
                    //Find Role Admin
                    var role = await _roleManager.FindByIdAsync(RoleId);
                    var result = await _userManager.AddToRoleAsync(UserId, role.Name);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        ViewBag.RoleId = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name");
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoleId = new SelectList(_roleManager.Roles, "Id", "Name");
                return View();
            }
        }
    }
}