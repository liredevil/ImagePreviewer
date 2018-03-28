using ImagePreviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagePreviewer.Controllers
{
    public class HomeController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        IEnumerable<Tag> tags = db.Tag;
        const int imageCount = 13;

        public ActionResult Index(int? id)
        {
            int page = id ?? 0;

            ViewBag.ImagePathes = GetItemsPage(page);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Items");
            }

            return View();
        }

        private IEnumerable<string> GetItemsPage(int pageNumber = 1)
        {
            int itemsToSkip = pageNumber * imageCount;

            return BildImagePathGroup().Skip(itemsToSkip).Take(imageCount).ToList();
        }

        private IEnumerable<string> BildImagePathGroup()
        {
            return db.Image.Select(p => "/UploadedFiles/" + p.Title);
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var models = tags.Where(a => a.TagTitle.Contains(term))
                            .Select(a => new { value = a.TagTitle })
                            .Distinct();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchOnTag(string tag)
        {
            IEnumerable<ImageTag> resultSeratching = db.ImageTag.Where(r => r.Tag.TagTitle == tag).ToList();
    
            return View(resultSeratching);
        }
    }
}