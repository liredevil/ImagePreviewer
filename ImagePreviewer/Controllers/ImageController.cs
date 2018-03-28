using ImagePreviewer.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagePreviewer.Controllers
{
    public class ImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(Image image, HttpPostedFileBase file, List<string> tags)
        {
            //var result = db.Image.Where(r => r.Title == (image.Title + ".jpg")).ToList();

            //if (result.Count > 0)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            if (ModelState.IsValid)
            {
                string fileName = image.Title + ".jpg";

                file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                image.Title = fileName;
                image.UserId = User.Identity.GetUserId();

                db.Image.Add(image);
                db.SaveChanges();

                Tag tagModel;
                ImageTag imageTagModel;
                if (tags != null)
                {
                    foreach (var tag in tags)
                    {
                        tagModel = new Tag();
                        imageTagModel = new ImageTag();

                        tagModel.TagTitle = tag;
                        db.Tag.Add(tagModel);
                        db.SaveChanges();


                        IEnumerable<Tag> getTagId = db.Tag.Where(g => g.TagTitle == tag);
                        foreach (var item in getTagId)
                        {
                            imageTagModel.TagId = item.Id;
                        }

                        IEnumerable<Image> getImageId = db.Image.Where(g => g.Title == fileName);
                        foreach (var item in getImageId)
                        {
                            imageTagModel.ImageId = item.Id;
                        }

                        db.ImageTag.Add(imageTagModel);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public JsonResult CheckUserName(string Title)
        {
            //var result = Membership.FindUsersByName(Title).Count == 0;
            return Json(!db.Image.Any(x => x.Title == Title), JsonRequestBehavior.AllowGet);
        }
    }
}