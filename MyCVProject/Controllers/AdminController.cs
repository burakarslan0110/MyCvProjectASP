using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCVProject.Models.Entity;
using MyCVProject.Repositories;

namespace MyCVProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> adrepo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var admins = adrepo.List();
            return View(admins);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Admin p)
        {
            adrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            Admin t = adrepo.Find(x => x.ID == id);
            adrepo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            Admin t = adrepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult AdminGetir(Admin p)
        {
            Admin t = adrepo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Parola = p.Parola;    
            adrepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}