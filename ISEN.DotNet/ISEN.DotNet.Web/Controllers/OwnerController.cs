using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Web.Controllers
{
    public class OwnerController : BaseController<IOwnerRepository, Owner>
    {
        public OwnerController(IOwnerRepository repository, ILogger<BaseController<IOwnerRepository, Owner>> logger, UserManager<AccountUser> userManager, IOwnerRepository ownerRepository) : base(repository, logger, userManager)
        {
        }

        public IActionResult MyEquipment()
        {
            var accountUserId = ViewData["Id"] = UserManager.GetUserId(User);
            var userOwner = Repository.Single(p => p.Account.Id == (int)accountUserId);
            return View(userOwner);
        }
    }
}