using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkersInfo.Data;
using WorkersInfo.Entities;

namespace Workers.Web.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
  
        public const string ALL_CATEGORIES = "...";

        public IEnumerable<Worker> Workers { get; set; }
        public NavigationController()
        {
            Workers = StaticDataContext.Workers;
        }
        [ChildActionOnly]
        public PartialViewResult WorkersByPosts_Menu(string categoryName = ALL_CATEGORIES)
        {
            ViewBag.SelectedNameCategory = categoryName;
            List<string> categoryNames = new List<string>();
            categoryNames.Add(ALL_CATEGORIES);
            categoryNames.AddRange(Workers.Select(e => e.Post.Name).Distinct().OrderBy(e => e));
            return PartialView(categoryNames);
        }
      
       
    }
}