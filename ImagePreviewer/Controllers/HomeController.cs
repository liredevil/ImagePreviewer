﻿using System.Collections.Generic;
using System.Web.Mvc;
using ImagePreviewer.Models;
using System.Linq;
using System.IO;

namespace ImagePreviewer.Controllers
{
    public class HomeController : Controller
    {
        private EFDbContext db = new EFDbContext();

        const int imageCount = 11;

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

        [HttpPost]
        public ActionResult SearchOnTag(string tag, int? id)
        {
            int page = id ?? 0;

            ViewBag.ImagePathes = GetItemsPage2(tag);

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



        private IEnumerable<string> GetItemsPage2(string tag)
        {
            int pageNumber = 1;
            int itemsToSkip = pageNumber * imageCount;

            return BildImagePathGroup2(tag).Skip(itemsToSkip).Take(imageCount).ToList();
        }

        private IEnumerable<string> BildImagePathGroup2(string tag)
        {
            return db.ImageTag.Where(p => p.Tag.TagTitle == tag).Select(p => "/UploadedFiles/" + p.Image.Title);
        }
    }
}