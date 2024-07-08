using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyCVProject.Models.Entity; 

namespace MyCVProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            CvDbEntities db = new CvDbEntities();
            var admin = db.Admin.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Parola == p.Parola);
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.KullaniciAdi, false);
                Session["KullaniciAdi"] = admin.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}