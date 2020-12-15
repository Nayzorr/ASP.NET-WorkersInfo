using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workers.Web.Models;
using WorkersInfo.Data;
using WorkersInfo.Entities;

namespace Workers.Web.Controllers
{
    public class WorkersController : Controller
    {
        // GET: Countries
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GoToMainMenu()
        {
            return PartialView();
        }

        private IEnumerable<Worker> objects;
        private IEnumerable<WorkerTableModel> workerTableModels;
        private IEnumerable<WorkerInfoModel> workerInfoModels;
        public IEnumerable<WorkerViewModel> workerViewModels;
        const string ALL_VALUES = "...";
        public IEnumerable<Worker> Objects
        {
            get
            {
                return objects;
            }
            set
            {
                
                objects = value;
                workerTableModels = objects.Select(e => (WorkerTableModel)e).OrderBy(e => e.Name);
                workerInfoModels = objects.Select(e => (WorkerInfoModel)e).OrderBy(e => e.Name);
                workerViewModels = objects.Select(e => (WorkerViewModel)e).OrderBy(e => e.Name);
            }
        }
        public int ItemsPerPage { get; set; }
        public const string ALL_PAGE_LINK_NAME = "..";
        public WorkersController()
        {
            Objects = StaticDataContext.Workers;
            ItemsPerPage = 2;
        }

        public ViewResult ObjectsInfo()
        {
            return View(Objects);
        }

        public ActionResult Selection()
        {
            ViewBag.selPost = CreatePostSelectList();
            return View(workerTableModels);
        }
        public PartialViewResult _DescriptiveInfo(int id)
        {
            var obj = Objects.First(e => e.Id == id);
            string[] model = null;
            if (!string.IsNullOrWhiteSpace(obj.Kharakteristika))
            {
                string s = "Характеристика:\n" + obj.Kharakteristika;
                model = s.Split(new[] { '\n' },
                StringSplitOptions.RemoveEmptyEntries);
            }
            return PartialView(model);

        }
        public ViewResult InfoWithPaging(string pageKey = "..", int pageNumber = 0)
        {
            IEnumerable<Worker> model = Objects.OrderBy(e => e.Name);
            if (!string.IsNullOrEmpty(pageKey) && pageKey != "..")
            {
                model = model.Where(e => e.Name[0].ToString() == pageKey);
            }
            if (pageNumber != 0)
            {
                model = model.Skip((pageNumber - 1) * ItemsPerPage).Take(ItemsPerPage);
            }
            return View(model);
        }
        public ViewResult WorkersByPostInfo(string categoryName = NavigationController.ALL_CATEGORIES)
        {
            IEnumerable<Worker> models = Objects.OrderBy(e => e.Name);
            if (!string.IsNullOrEmpty(categoryName) && categoryName != NavigationController.ALL_CATEGORIES)
            {
                models = models.Where(e => e.Post.Name == categoryName);
            }
            ViewBag.SelectedCategoryName = categoryName;
            return View(models);
        }
        public PartialViewResult _SelectData(string selName, string selPost, int? expFrom, int? expTo)
        {
            var model = workerTableModels;
            if (!string.IsNullOrEmpty(selName))
                model = model.Where(e => e.Name.ToLower().StartsWith(selName.ToLower()));
            if (selPost != null && selPost != ALL_VALUES)
                model = model.Where(e => e.Post == selPost);
            if (expFrom.HasValue)
            {
                model = model.Where(e => e.Exp >= expFrom);
            }
            if (expTo.HasValue)
            {
                model = model.Where(e => e.Exp <= expTo);
            }
            System.Threading.Thread.Sleep(2000);
            return PartialView("_TableBody", model);
        }
        List<SelectListItem> CreatePostSelectList()
        {
            List<string> values = new List<string>();
            values.Add(ALL_VALUES);
            values.AddRange(Objects.Select(e => e.Post.Name).Distinct());
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string e in values)
            {
                list.Add(new SelectListItem { Text = e, Value = e });
            }
            return list;
        }
        public ActionResult BrowseByLetter()
        {
            ViewBag.Letters = new[] { ALL_PAGE_LINK_NAME }.Concat(Objects.Select(e => e.Name[0].ToString()).Distinct().OrderBy(e => e));
            return View(workerInfoModels);
        }
        public PartialViewResult _GetDataByLetter(string selLetter)
        {
            var model = workerInfoModels;
            if (!string.IsNullOrEmpty(selLetter) && selLetter != ALL_PAGE_LINK_NAME)
                model = model.Where(e => e.Name[0] == selLetter[0]);
            System.Threading.Thread.Sleep(2000);
            return PartialView("_BrowseData", model);
        }
        public ActionResult List()
        {          
            return View(workerViewModels);
        }
        public ViewResult _Details(int id)
        {
            var obj = workerViewModels.First(e => e.Id==id);
            return View(obj);
        }
        string[] GetInfo(int id)
        {
            var obj = Objects.First(e => e.Id == id);

            string s = null;
            if (!string.IsNullOrWhiteSpace(obj.Kharakteristika))
            {
                s += "Характеристика:\n" + obj.Kharakteristika + "\n";
            }
            if (!string.IsNullOrWhiteSpace(obj.Bio))
            {
                s += "Біографія:\n" + obj.Bio + "\n";
            }
            string[] info = null;
            if (s != null)
            {
                info = s.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return info;
        }
        [HttpPost]
        public JsonResult JsonInfo(int id)
        {
            var info = GetInfo(id);
            System.Threading.Thread.Sleep(2000);
            return Json(info);
        }
        public ViewResult Browse()
        {
            return View(workerViewModels);
        }
        [HttpPost]
        public JsonResult JsonIdInfo(int id)
        {
            var info = GetInfo(id);
            return Json(new { Id = id, Info = info });
        }
    }
}