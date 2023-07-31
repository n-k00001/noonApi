
using Microsoft.AspNetCore.Mvc;
using noon.Domain.Models.Identity;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Identity;
using noon.DTO.RoleVM;
using Microsoft.AspNetCore.Authorization;

namespace noonDashboard.MVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var Roles = roleManager.Roles;
            return View(Roles);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var data = await roleManager.FindByIdAsync(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {

            var role = new IdentityRole()
            {

                Name = model.Name,
                NormalizedName = model.Name.ToUpper()
            };

            var result = await roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }


            return View(model);
        }


        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole model)
        {

            var role = await roleManager.FindByIdAsync(model.Id);

            role.Name = model.Name;
            role.NormalizedName = model.Name.ToUpper();
            role.ConcurrencyStamp = model.ConcurrencyStamp;

            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }


            return View(model);
        }





        public async Task<IActionResult> AddOrRemoveUsers(string RoleId)
        {
            if (RoleId == null)
                return NotFound();

            ViewBag.RoleId = RoleId;

            var role = await roleManager.FindByIdAsync(RoleId);
            if (role == null)
                return NotFound();

            var model = new List<UserInRoleVM>();

            foreach (var user in userManager.Users)
            {
                var userInRole = new UserInRoleVM()
                {
                    UserId = user.Id,
                    Email = user.Email
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userInRole.IsSelected = true;
                }
                else
                {
                    userInRole.IsSelected = false;
                }

                model.Add(userInRole);
            }

            return View(model);


        }



        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUsers(List<UserInRoleVM> model, string RoleId)
        {

            var role = await roleManager.FindByIdAsync(RoleId);

            for (int i = 0; i < model.Count; i++)
            {

                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {

                    result = await userManager.AddToRoleAsync(user, role.Name);

                }
                else if (!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                //else
                //{
                //    continue;
                //}

                //if (i < model.Count)
                //    continue;


            }

            return RedirectToAction("Edit", new { id = RoleId });
        }



        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(role);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(IdentityRole model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var role = await roleManager.FindByIdAsync(model.Id);

                    var result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }


                }

                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }

        }
    }
}
