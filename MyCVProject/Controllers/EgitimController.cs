using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCVProject.Models.Entity;
using MyCVProject.Repositories;

namespace MyCVProject.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<Egitimlerim> egtmrepo = new GenericRepository<Egitimlerim>();

        public ActionResult Index()
        {
            var degerler = egtmrepo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(Egitimlerim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            egtmrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            Egitimlerim t = egtmrepo.Find(x => x.ID == id);
            egtmrepo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            Egitimlerim t = egtmrepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimGetir(Egitimlerim p)
        {
            Egitimlerim t = egtmrepo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2 = p.AltBaslik2;
            t.Tarih = p.Tarih;
            t.Ortalama = p.Ortalama;
            egtmrepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}