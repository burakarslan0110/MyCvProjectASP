using MyCVProject.Models.Entity;
using MyCVProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCVProject.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository dnymrepo = new DeneyimRepository(); //bu nesne GenericRepository'deki CRUD metodlarını miras aldı. 
        public ActionResult Index()
        {
            var degerler = dnymrepo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult DeneyimEkle(Deneyimlerim p)
        {
            dnymrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            Deneyimlerim t = dnymrepo.Find(x=>x.ID==id);
            dnymrepo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Deneyimlerim t = dnymrepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(Deneyimlerim p)
        {
            Deneyimlerim t = dnymrepo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;    
            t.DeneyimLink = p.DeneyimLink;
            dnymrepo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}