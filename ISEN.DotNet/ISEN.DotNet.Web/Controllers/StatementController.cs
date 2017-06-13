using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Web.Controllers
{
    public class StatementController : BaseController<IStatementRepository, Statement>
    {
        public StatementController(IStatementRepository repository, ILogger<BaseController<IStatementRepository, Statement>> logger) : base(repository, logger)
        {
        }

        public override IActionResult Index()
        {
            var model = Repository.GetAll();
            return View(model);
        }
    }
}