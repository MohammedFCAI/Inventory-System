using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Entities;
using InventorySystem.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventorySystem.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userModel)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                };

                var result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    // Create Cookie with Id, Name and Role.
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    var claims = new List<Claim>();

                    await _signInManager.SignInWithClaimsAsync(user, false, claims);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(userModel);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                // Check database
                var user = await _userManager.FindByEmailAsync(userModel.Email);
                if (user is not null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, userModel.Password);
                    if (result)
                    {
                        // Create cookie
                        await _signInManager.SignInAsync(user, userModel.RememberMe);
                        var lowQuantityProducts = await _unitOfWork.Products.GetLowQuantityProductsAsync(50);

                        if (lowQuantityProducts.Any())
                        {
                            var message = $"Warning: {lowQuantityProducts.Count()} products have a quantity below 50!";
                            TempData["LowQuantityMessage"] = message;
                        }
                        return RedirectToAction("Index", "Dashboard");
                    }

                    else
                    {
                        ModelState.AddModelError("", "Invalid User name or Passowrd");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or Passowrd");
                }
            }
            return View(userModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
