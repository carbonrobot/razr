using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razr.Models;
using Razr.Web.Models;

namespace Razr.Web.Controllers
{
    public class PostController : BaseController
    {

        [HttpGet] // post/{id}
        public ActionResult Index(int id)
        {
            return View();
        }

        [HttpGet] // post/{id}/edit
        public ActionResult Edit(int id)
        {
            var response = service.Get<Post>(id);
            var model = new EditViewModel()
            {
                Post = response.Result
            };
            return View(model);
        }

        [HttpPost] // post/{id}/edit
        public ActionResult Edit(EditViewModel model)
        {
            var entity = service.Get<Post>(model.Post.Id).Result;
            this.UpdateModel(entity, "Post");
            var response = service.Save(entity);

            return this.Redirect("/admin");
        }

        [HttpPost] // post/quick/{title}
        public ActionResult Quick(string title)
        {
            var response = service.CreateQuickDraft(title);
            return this.Redirect("/admin");
        }

    }
}
