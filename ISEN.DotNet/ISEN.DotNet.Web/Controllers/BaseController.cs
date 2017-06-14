using Microsoft.AspNetCore.Mvc;
using ISEN.DotNet.Library.Repositories.Interfaces;
using ISEN.DotNet.Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Web.Controllers
{
    public abstract class BaseController<IRepo, T> : Controller
        where IRepo : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly ILogger<BaseController<IRepo, T>> Logger; 
        protected readonly IRepo Repository;
        protected readonly UserManager<AccountUser> UserManager;

        public BaseController(
            IRepo repository,
            ILogger<BaseController<IRepo, T>> logger,
            UserManager<AccountUser> userManager)
        {
            Repository = repository;
            Logger = logger;
            UserManager = userManager;
        }

        [HttpGet]
        public virtual JsonResult All()
        {
            var model = Repository.GetAll();
            return Json(model);
        }

        public virtual IActionResult Index()
        {
            var model = Repository.GetAll();
            return View(model);
        }

        public virtual IActionResult Detail(int? id)
        {
            if (id == null) return View();          
            var model = Repository.Single(id.Value);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Detail(T entity)
        {
            Repository.Update(entity);
            Repository.Save();
            return RedirectToAction("Index");
        }

        public virtual IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Repository.Delete(id.Value);
                Repository.Save();
            }
            return RedirectToAction("Index");
        }
    }
}
