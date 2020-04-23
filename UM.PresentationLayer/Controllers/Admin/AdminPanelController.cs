using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UM.PresentationLayer.Controllers.Admin
{
    public class AdminPanelController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        [Route("adminpanel/dashboard")]
        public ActionResult Index()
        {
            return View();
        }
    }
}