using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ISEN.DotNet.Library.Data;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Models.AccountViewModels;
using ISEN.DotNet.Library.Repositories.Interfaces;

namespace ISEN.DotNet.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AccountUser> _userManager;
        private readonly SignInManager<AccountUser> _signInManager;
        private readonly RoleManager<AccountRole> _roleManager;
        private readonly ILogger _logger;
        private readonly string _externalCookieScheme;
        private readonly IOwnerRepository _ownerRepository;

        public AccountController(
            ApplicationDbContext context,
            UserManager<AccountUser> userManager,
            SignInManager<AccountUser> signInManager,
            IOptions<IdentityCookieOptions> identityCookieOptions,  
            IOwnerRepository ownerRepository,
            ILoggerFactory loggerFactory, RoleManager<AccountRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _ownerRepository = ownerRepository;
            _externalCookieScheme = identityCookieOptions.Value.ExternalCookieAuthenticationScheme;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        public IActionResult Index()
        {         
            return View(_context.AccountUserCollection);
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.Authentication.SignOutAsync(_externalCookieScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    ViewData["Id"] = _userManager.GetUserId(User);
                    _logger.LogInformation(1, "User logged in.");
                    return RedirectToLocal(returnUrl);
                }               
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new AccountUser {UserName = model.UserName, Email = model.Email};
                var owner = new Owner
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    City = model.City,
                    Country = model.Country,
                    Account = user
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                _ownerRepository.Update(owner);
                _ownerRepository.Save();
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        //
        // POST: /Account/Logout
        [AllowAnonymous]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return RedirectToAction("Index", "Home");
        }

        //
        // GET /Account/AccessDenied
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public virtual IActionResult Detail(int? id)
        {
            if (id == null) return View();
            var model = _context.AccountUserCollection.Single(p => p.Id == id);
            _logger.LogWarning(model.UserName);
            return View(model);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}
