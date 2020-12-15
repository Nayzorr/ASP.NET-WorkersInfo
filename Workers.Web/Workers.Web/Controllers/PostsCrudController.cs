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
    public class PostsCrudController : Controller
    {
        // GET: PostsCrud
        public ActionResult Index()
        {
            return View(postSelectionModels);
        }
        private ICollection<Post> posts;
        private IEnumerable<PostSelectionModel> postSelectionModels;      
        private IEnumerable<PostEditingModel> postEditingModels;
        public ICollection<Post> Posts
        {
            get
            {
                return posts;
            }
            set
            {
                posts = value;
                postSelectionModels = posts.Select(e => (PostSelectionModel)e).OrderBy(e => e.Name);
                postEditingModels = posts.Select(e => (PostEditingModel)e).OrderBy(e => e.Name);
            }
        }
        public IEnumerable<Worker> Workers { get; set; }
        public PostsCrudController()
        {
            Posts = StaticDataContext.Posts;
            Workers = StaticDataContext.Workers;           
        }

        public ActionResult Create()
        {         
            return View(new PostEditingModel());
        }
        [HttpPost]
        
        public ActionResult Create(PostEditingModel model)
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
                    return View(model);
                }
                Posts.Add((Post)model);
                StaticDataContext.Save();
                TempData["Message"] = string.Format("Об'єкт \"{0}\" успішно створено", model.Name);
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Edit(int id)
        {
            var model = postEditingModels.First(e => e.Id == id);         
            return View(model);
        }
        [HttpPost]
    
        public ActionResult Edit(PostEditingModel model)
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
                    return View(model);
                }
                var entityObject = Posts.First(e => e.Id == model.Id);
                UpdateEntityModel(entityObject, model);
                StaticDataContext.Save();
                TempData["Message"] = string.Format(
                   "Зміни даних працівника \"{0}\" збережено", model.Name);
                return RedirectToAction("Index");
            }
            
        }

        private void UpdateEntityModel(Post entityObject, PostEditingModel model)
        {
            entityObject.Name = model.Name;     
            entityObject.Code = model.Code;
            entityObject.State_Units= model.State_Units;
            entityObject.Notice = model.Notice;         
        }
        public ActionResult Delete(int id)
        {
            var model = postEditingModels.First(e => e.Id == id);
            return View(model);
        }
        [HttpPost]
       
        public ActionResult Delete(Post model)
        {

            if (User.Identity.Name != "admin")
            {
                TempData["NoAdmin"] = string.Format("У вас немає прав адміністратора");
                return RedirectToAction("Index");
            }
            else
            {
                Post entityObject = Posts.First(e => e.Id == model.Id);
                int workers_of_this_post_count = 0;
                foreach (var el in Workers)
                {
                    if (entityObject.Name == el.Post.Name)
                    {
                        workers_of_this_post_count++;
                    }
                }
                if (workers_of_this_post_count == 0)
                {
                    Posts.Remove(entityObject);
                    StaticDataContext.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["CannotToDelete"] = string.Format("Неможливо видалити, кількість працівників на посаді \"{0}\" - {1} ", entityObject.Name, workers_of_this_post_count);
                    return RedirectToAction("Index");
                }
            }
            
            
        }
        public ActionResult Details(int id)
        {
            var model = postEditingModels.First(e => e.Id == id);
            return View(model);
        }
    }
}