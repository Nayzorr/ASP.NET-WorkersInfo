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
    public class PostsController : Controller
    {
        // GET: Posts
        public PartialViewResult GoToMainMenu()
        {
            return PartialView();
        }
 
        public ActionResult Index()
        {
            return View();
        }
        private IEnumerable<Post> posts;
        private IEnumerable<PostTableModel> postTableModels;
        private IEnumerable<PostViewModel> postViewModels;
        private IEnumerable<PostInfoModel> postInfoModels;
        public IEnumerable<Post> Posts
        {
            get
            {
                return posts;
            }
            set
            {
                posts = value;
                postTableModels = posts.Select(e => (PostTableModel)e).OrderBy(e => e.Name);
                postViewModels= posts.Select(e => (PostViewModel)e).OrderBy(e => e.Name);
                postInfoModels = posts.Select(e => (PostInfoModel)e).OrderBy(e => e.Name);
            }
        }
        public int ItemsPerPage { get; set; }
        public PostsController()
        {
            Posts = StaticDataContext.Posts;
            ItemsPerPage = 2;
        }
        public ViewResult ObjectsInfo()
        {
            return View(Posts);
        }
        public PartialViewResult _DescriptiveInfo(int id)
        {
            var obj = Posts.First(e => e.Id == id);
            string[] model = null;
            if (!string.IsNullOrWhiteSpace(obj.Notice))
            {
                string s = "Примітка:\n" + obj.Notice;
                model = s.Split(new[] { '\n' },
                StringSplitOptions.RemoveEmptyEntries);
            }
            return PartialView(model);

        }
       
        public ViewResult InfoWithPaging(string pageKey = "..", int pageNumber = 0)
        {
            IEnumerable<Post> model = Posts.OrderBy(e => e.Name);
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
   
        public ActionResult Selection()
        {           
            return View(postTableModels);
        }
        public PartialViewResult _SelectData(string selName, int? state_units_From, int? state_units_To)
        {
            var model = postTableModels;
            if (!string.IsNullOrEmpty(selName))
                model = model.Where(e => e.Name.ToLower().StartsWith(selName.ToLower()));           
            if (state_units_From.HasValue)
            {
                model = model.Where(e => e.State_Units >= state_units_From);
            }
            if (state_units_To.HasValue)
            {
                model = model.Where(e => e.State_Units <= state_units_To);
            }
            System.Threading.Thread.Sleep(2000);
            return PartialView("_TableBody", model);
        }
 
        public ActionResult List()
        {
            return View(postViewModels);
        }
        public ViewResult _Details(int id)
        {
            var obj = postViewModels.First(e => e.Id == id);
            return View(obj);
        }
        string[] GetInfo(int id)
        {
            var obj = Posts.First(e => e.Id == id);

            string s = null;
            if (!string.IsNullOrWhiteSpace(obj.Notice))
            {
                s += "Примітка:\n" + obj.Notice + "\n";
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
        [Authorize]
        public ViewResult Browse()
        {
            return View(postViewModels);
        }
        [HttpPost]
 
        public JsonResult JsonIdInfo(int id)
        {
            var info = GetInfo(id);
            return Json(new { Id = id, Info = info});
        }

        public const string ALL_PAGE_LINK_NAME = "..";
 
        public ActionResult BrowseByLetter()
        {
            ViewBag.Letters = new[] { ALL_PAGE_LINK_NAME }.Concat(Posts.Select(e => e.Name[0].ToString()).Distinct().OrderBy(e => e));
            return View(postInfoModels);
        }
        public PartialViewResult _GetDataByLetter(string selLetter)
        {
            var model = postInfoModels;
            if (!string.IsNullOrEmpty(selLetter) && selLetter != ALL_PAGE_LINK_NAME)
                model = model.Where(e => e.Name[0] == selLetter[0]);
            System.Threading.Thread.Sleep(2000);
            return PartialView("_BrowseData", model);
        }
    }
}