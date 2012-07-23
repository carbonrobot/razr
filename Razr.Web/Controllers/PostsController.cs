using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razr.Models;
using Razr.Web.Models;

namespace Razr.Web.Controllers
{
    [Authorize]
    public class PostsController : BaseController
    {

        [HttpGet] // GET: /posts/{id}
        public ActionResult Index(int id)
        {
            var response = Service.Get<Post>(id);
            var post = response.Result;
            return View(post);
        }
        
        [HttpGet] // GET: /posts/{id}/edit
        public ActionResult Edit(int id)
        {
            var response = Service.Get<Post>(id);
            var model = new EditViewModel()
            {
                Post = response.Result
            };
            return View(model);
        }

        [HttpPost, ValidateInput(false)] // POST: /posts/{id}/edit
        public ActionResult Edit(EditViewModel model)
        {
            var entity = Service.Get<Post>(model.Post.Id).Result;
            this.UpdateModel(entity, "Post");
            var response = Service.Save(entity);

            return this.Redirect("/admin");
        }

        [HttpPost] // POST: /posts/quick/{title}
        public ActionResult Quick(string title)
        {
            var response = Service.CreateQuickDraft(title);
            return this.Redirect("/admin");
        }

        [HttpPost] // posts/{id}/delete
        public ActionResult Delete(int id)
        {
            var response = Service.Delete<Post>(id);
            return this.Redirect("/admin");
        }

        [HttpPost] // posts/{id}/publish
        public ActionResult Publish(int id)
        {
            var response = Service.Publish(id);
            if (response.HasError)
                this.RedirectToError("Could not publish post", response.Exception);

            return this.RedirectToAction("Edit", new { id = id });
        }

        [HttpPost] // posts/{id}/retract
        public ActionResult Retract(int id)
        {
            var response = Service.Retract(id);
            if (response.HasError)
                this.RedirectToError("Could not retract post", response.Exception);

            return this.RedirectToAction("Edit", new { id = id });
        }

    }
}
