using Castle.Core.Resource;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using noon.Domain.Models.Identity;
using noon.DTO.AdminAccountVM;

namespace noonDashboard.MVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController( RoleManager<IdentityRole> roleManager,  UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        #region Registration (Sign up)
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    UserAddress userAddress = new UserAddress();
                    var user = new AppUser()
                    {

                        UserName = model.Email,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        DisplayName = model.DisplayName
                        //var userAdd = new UserAddress()
                        //{

                        //}

                    };

                    var result = await userManager.CreateAsync(user, model.Password);


                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "store");
                        return RedirectToAction("Login");
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
            catch (Exception)
            {
                return View(model);
            }

            return View();
        }
        #endregion



        #region Login (Sign in)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByEmailAsync(model.Email);

                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName or Password");
                    }

                }

                return View(model);

            }
            catch (Exception)
            {
                return View(model);
            }
            return View();
        }


        #endregion


        #region LogOff (Sign Out)

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion
    }
}
