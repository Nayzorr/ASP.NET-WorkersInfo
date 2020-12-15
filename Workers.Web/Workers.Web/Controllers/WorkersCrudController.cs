using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Workers.Web.Models;
using WorkersInfo.Data;
using WorkersInfo.Entities;

namespace Workers.Web.Controllers
{
    public class WorkersCrudController : Controller
    {
        // GET: WorkersCrud
        private ICollection<Worker> workers;
        private IEnumerable<WorkerSelectionModel> workerSelectionModels;
        private IEnumerable<WorkerEditingModel> workerEditingModels;

        public ICollection<Worker> Workers
        {
            get
            {
                return workers;
            }
            set
            {
                workers = value;
                workerSelectionModels = workers.Select(e => (WorkerSelectionModel)e).OrderBy(e => e.Name);
                workerEditingModels = workers.Select(e => (WorkerEditingModel)e).OrderBy(e => e.Name);
            }
        }
        public IEnumerable<Post> Posts { get; set; }
        public WorkersCrudController()
        {
            Workers = StaticDataContext.Workers;
            Posts = StaticDataContext.Posts;
        }
        [Authorize]
        public ActionResult Index()
        {
            return View(workerSelectionModels);
        }
       
        public ActionResult Create()
        {
            ViewBag.Post = CreatePostNameSelectList();
            return View(new WorkerEditingModel());
        }
        [HttpPost]
       
        public ActionResult Create(WorkerEditingModel model)
        {
            if (User.Identity.Name != "admin")
            {
                TempData["NoAdmin"] = string.Format("У вас немає прав адміністратора");
                return RedirectToAction("Index");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Post = CreatePostNameSelectList();
                    return View(model);
                }
                Workers.Add(WorkerEditingModel.ToWorker(model, Posts));
                StaticDataContext.Save();
                TempData["Message"] = string.Format("Об'єкт \"{0}\" успішно створено", model.Name);
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Edit(int id)
        {
            var model = workerEditingModels.First(e => e.Id == id);
            ViewBag.Post = CreatePostNameSelectList(model.Post);
            return View(model);
        }
        [HttpPost]       
        public ActionResult Edit(WorkerEditingModel model)
        {
            if (User.Identity.Name != "admin")
            {
                TempData["NoAdmin"] = string.Format("У вас немає прав адміністратора");
                return RedirectToAction("Index");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Post = CreatePostNameSelectList(model.Post);
                    return View(model);
                }
                var entityObject = Workers.First(e => e.Id == model.Id);
                UpdateEntityModel(entityObject, model);
                StaticDataContext.Save();
                TempData["Message"] = string.Format(
                   "Зміни даних працівника \"{0}\" збережено", model.Name);
                return RedirectToAction("Index");
            }
           
        }

        private void UpdateEntityModel(Worker entityObject, WorkerEditingModel model)
        {
            entityObject.Name = model.Name;
            entityObject.Post = Posts.First(e => e.Name == model.Post);
            entityObject.Unit = model.Unit;
            entityObject.Exp = model.Exp;
            entityObject.Kharakteristika = model.Kharakteristika;
            entityObject.Bio = model.Bio;
        }      
        public ActionResult Delete(int id)
        {          
            var model = workerEditingModels.First(e => e.Id == id);
            return View(model);
        }
        [HttpPost]      
        public ActionResult Delete(Worker model)
        {
            if (User.Identity.Name != "admin")
            {
                TempData["NoAdmin"] = string.Format("У вас немає прав адміністратора");
                return RedirectToAction("Index");
            }
            else
            {
                Worker entityObject = Workers.First(e => e.Id == model.Id);
                Workers.Remove(entityObject);
                StaticDataContext.Save();
                return RedirectToAction("Index");
            }           
        }
        public ActionResult Details(int id)
        {
            var model = workerEditingModels.First(e => e.Id == id);
            return View(model);
        }

        List<SelectListItem> CreatePostNameSelectList(string selectedValue = "")
        {
            List<string> values = new List<string>();
            values.AddRange(Posts.Select(e => e.Name));
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string e in values)
            {
                list.Add(new SelectListItem
                {
                    Text = e,
                    Value = e,
                    Selected = e == selectedValue
                });
            }
            return list;
        }
        [Authorize(Users = "admin")]
        public ActionResult DeleteAll()
        {
            if (User.Identity.Name != "admin")
            {
                TempData["NoAdmin"] = string.Format("У вас немає прав адміністратора");
                return RedirectToAction("Index");
            }
            else
            {
                Workers.Clear();
                workerSelectionModels = workers.Select(e => (WorkerSelectionModel)e).OrderBy(e => e.Name);
                StaticDataContext.Save();
                TempData["Message"] = string.Format("Успішно видалено всіх працівників");
                return PartialView("_TableBody", workerSelectionModels);
            }
            
        }

    }
}