using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Web.Controllers
{
    public class StatementController : BaseController<IStatementRepository, Statement>
    {
        public StatementController(IStatementRepository repository, ILogger<BaseController<IStatementRepository, Statement>> logger, UserManager<AccountUser> userManager) : base(repository, logger, userManager)
        {
        }

        public IActionResult Info()
        {
            var accountUserId = ViewData["Id"] = UserManager.GetUserId(User);
            var userOwner = Repository.Find(p => p.Equipment.Owner.Account.Id == (int)accountUserId);
            return View(userOwner);
        }
    }
}