using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Web.Controllers
{
    public class EquipmentController : BaseController<IEquipmentRepository, Equipment>
    {
        public IOwnerRepository OwnerRepository;
        public EquipmentController(IEquipmentRepository repository, ILogger<BaseController<IEquipmentRepository, Equipment>> logger, UserManager<AccountUser> userManager, IOwnerRepository ownerRepository) : base(repository, logger, userManager)
        {
            OwnerRepository = ownerRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual IActionResult Create(Equipment equipment)
        {
            Repository.Update(equipment);
            Repository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Enrole()
        {
            return View();
        }

        [HttpPost]
        public virtual IActionResult Enrole(Equipment equipment)
        {
            var enrole = Repository.Single(p => p.IdObject == equipment.IdObject);
            if (enrole.Owner == null)
            {
                var accountUserId = ViewData["Id"] = UserManager.GetUserId(User);
                var userOwner = OwnerRepository.Single(p => p.Account.Id == (int)accountUserId);
                Logger.LogWarning("bla");
                enrole.Owner = userOwner;
                enrole.IdObject = equipment.IdObject;
                enrole.Name = equipment.Name;
                Repository.Update(enrole);
                Repository.Save();
                return RedirectToAction("MyEquipment", "Owner");
            }
            return RedirectToAction("Enrole");
        }
    }
}