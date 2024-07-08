using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCVProject.Models.Entity;
using MyCVProject.Repositories;

namespace MyCVProject.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<Hakkimda> hkmrepo = new GenericRepository<Hakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = hkmrepo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(Hakkimda p)
        {
            var t = hkmrepo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;  
            t.Telefon = p.Telefon;  
            t.Eposta = p.Eposta;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            hkmrepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}