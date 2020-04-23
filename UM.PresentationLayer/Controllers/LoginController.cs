using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UM.BusinessLayer.Abstract;
using UM.BusinessLayer.Concrete;
using UM.DataAccessLayer.Abstract;
using UM.DataAccessLayer.Concrete.EFConcrete;
using UM.EntitiesLayer;
using UM.PresentationLayer.Models;

namespace UM.PresentationLayer.Controllers
{

    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(EntitiesLayer.user user)
        {

            var response = Request["g-recaptcha-response"];
            const string secret = "6LekUuwUAAAAAIDI-PnEx_0mG3ClyxokbBGXMSOe";
            //Kendi Secret keyinizle değiştirin.

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaModel>(reply);

            if (!captchaResponse.Success)
            {
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                return RedirectToAction("Index");
            }
            else
            {
                UserConcrete DB = new UserConcrete();
                var sonuc = DB.GetFilter(x => x.First_Name == user.First_Name && x.Password == user.Password).FirstOrDefault();
                if (sonuc != null)
                {
                    FormsAuthentication.SetAuthCookie(user.First_Name, false);
                    return RedirectToAction("RedirectLogin");
                }
                else
                {
                    ViewBag.mesaj = "geçersiz şifre veya kullanıcı adı";
                    return View();
                }
            }
        }
        public ActionResult RedirectLogin()
        {
            if (User.IsInRole("ADMIN"))
            {
                return RedirectToAction("dashboard", "adminpanel");
            }
            else
            {
                return RedirectToAction("home", "blog");
            }
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}