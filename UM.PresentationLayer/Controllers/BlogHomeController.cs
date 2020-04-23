using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UM.PresentationLayer.Controllers
{
    public class BlogHomeController : Controller
    {
        [Authorize(Roles = "USER")]
        [Route("blog/home")]
        public ActionResult Index()
        {
            return View();
        }
    }
}