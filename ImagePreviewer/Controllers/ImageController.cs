using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ImagePreviewer.Models;
using ImagePreviewer.logic;
using System.IO;
using Microsoft.AspNet.Identity;
using System;
namespace ImagePreviewer.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private EFDbContext db = new EFDbContext();
       
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Upload()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Upload(ImageModel image, HttpPostedFileBase file)
        {
            if(ModelState.IsValid)
            {
                string fileName = file.FileName;
                file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                image.Title = file.FileName;
                image.UserId = User.Identity.GetUserId();

                db.Image.Add(image);
                db.SaveChanges();
               
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult AddTag(string name)
        {
            TagModel tag = new TagModel();

            if (ModelState.IsValid)
            {
                tag.TagTitle = name;

                db.Tag.Add(tag);
                db.SaveChanges();
            }

            IEnumerable<TagModel> teg = db.Tag;

            return PartialView(teg);
        }    

        public ActionResult Delete(int id)
        {
            TagModel tag = db.Tag.Find(id);

            if (tag != null)
            {
                db.Tag.Remove(tag);
                db.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Drag(HttpPostedFileBase file)
        {
            string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
            file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), filePath));            

            return Json("file uploaded successfully");
        }


    }
}