using System.Collections.Generic;
using System.Web.Mvc;

namespace ImagePreviewer.Controllers
{
    public class TagController : Controller
    {

        

        public ActionResult Index()
        {
            
            return View();
        }

        //public ActionResult AddTag(string name)
        //{

        //    tagList.Add(name);

        //    return PartialView(tagList);
        //}

    }
}