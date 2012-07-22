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
    public class PostController : BaseController
    {

        [HttpGet] // post/{id}/edit
        public ActionResult Edit(int id)
        {
            var response = Service.Get<Post>(id);
            var model = new EditViewModel()
            {
                Post = response.Result
            };
            return View(model);
        }

        [HttpPost, ValidateInput(false)] // post/{id}/edit
        public ActionResult Edit(EditViewModel model)
        {
            var entity = Service.Get<Post>(model.Post.Id).Result;
            this.UpdateModel(entity, "Post");
            var response = Service.Save(entity);

            return this.Redirect("/admin");
        }

        [HttpPost] // post/quick/{title}
        public ActionResult Quick(string title)
        {
            var response = Service.CreateQuickDraft(title);
            return this.Redirect("/admin");
        }

        [HttpPost] // post/{id}/delete
        public ActionResult Delete(int id)
        {
            var response = Service.Delete<Post>(id);
            return this.Redirect("/admin");
        }

        [HttpPost] // post/{id}/publish
        public ActionResult Publish(int id)
        {
            var response = Service.Publish(id);
            if (response.HasError)
                this.RedirectToError("Could not publish post", response.Exception);

            return this.RedirectToAction("Edit", new { id = id });
        }

        [HttpPost] // post/{id}/retract
        public ActionResult Retract(int id)
        {
            var response = Service.Retract(id);
            if (response.HasError)
                this.RedirectToError("Could not retract post", response.Exception);

            return this.RedirectToAction("Edit", new { id = id });
        }

    }
}
