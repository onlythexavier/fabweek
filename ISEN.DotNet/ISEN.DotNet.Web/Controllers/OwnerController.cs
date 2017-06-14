using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Web.Controllers
{
    public class OwnerController : BaseController<IOwnerRepository, Owner>
    {
        public OwnerController(IOwnerRepository repository, ILogger<BaseController<IOwnerRepository, Owner>> logger) : base(repository, logger)
        {
        }

        public override IActionResult Index()
        {
            var model = Repository.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult Inscription(Owner owner)
        {
            Logger.LogWarning(owner.Id.ToString());
            Repository.Update(owner);
            Repository.Save();
            return RedirectToAction("Detail", "Owner");
        }
    }
}