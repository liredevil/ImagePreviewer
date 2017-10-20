using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ImagePreviewer.Models;
using ImagePreviewer.logic;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Identity;
using System;

namespace ImagePreviewer.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private EFDbContext db = new EFDbContext();

        

        public ImageController()
        {

        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Upload()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Upload(ImageModel image, HttpPostedFileBase file,List<string> tags)
        {
            if(ModelState.IsValid)
            {
                string fileName = image.Title + ".jpg";
                
                file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                image.Title = fileName;
                image.UserId = User.Identity.GetUserId();

                db.Image.Add(image);
                db.SaveChanges();

                TagModel tagModel;
                ImageTagModel imageTagModel;
                if (tags != null) 
                {
                    foreach (var tag in tags)
                    {
                        tagModel = new TagModel();
                        imageTagModel = new ImageTagModel();
                        //IEnumerable<TagModel> chekSameField = db.Tag.Where(g => g.TagTitle == item);
                        //if (db.Tag.Count() == 0)
                        //{
                        //    tagModel.TagTitle = item;
                        //    db.Tag.Add(tagModel);
                        //    db.SaveChanges();
                        //}
                        //foreach (var q in chekSameField)
                        //{
                        //    if (item.ToString() != q.TagTitle)
                        //    {
                                tagModel.TagTitle = tag;
                                db.Tag.Add(tagModel);
                                db.SaveChanges();
                        //    }
                        //}

                        IEnumerable<TagModel> getTagId = db.Tag.Where(g => g.TagTitle == tag);
                        foreach (var item in getTagId)
                        {
                            imageTagModel.TagId = item.Id;
                        }

                        IEnumerable<ImageModel> getImageId = db.Image.Where(g => g.Title == fileName);
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
    }
}