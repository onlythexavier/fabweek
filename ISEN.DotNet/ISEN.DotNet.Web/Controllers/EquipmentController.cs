using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Web.Controllers
{
    public class EquipmentController : BaseController<IEquipmentRepository, Equipment>
    {
        public EquipmentController(IEquipmentRepository repository, ILogger<BaseController<IEquipmentRepository, Equipment>> logger, UserManager<AccountUser> userManager) : base(repository, logger, userManager)
        {
        }
    }
}