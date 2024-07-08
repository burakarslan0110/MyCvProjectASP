using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCVProject.Models.Entity;
using MyCVProject.Repositories;

namespace MyCVProject.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Sertifikalarim> srtrepo = new GenericRepository<Sertifikalarim>();
        public ActionResult Index()
        {
            var sertifika = srtrepo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = srtrepo.Find(x => x.ID == id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(Sertifikalarim t)
        {
            var sertifika = srtrepo.Find(x => x.ID == t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Baslik = t.Baslik;
            sertifika.Tarih=t.Tarih;
            sertifika.Dogrulama = t.Dogrulama;
            srtrepo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(Sertifikalarim p)
        {
            srtrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            Sertifikalarim t = srtrepo.Find(x => x.ID == id);
            srtrepo.TRemove(t);
            return RedirectToAction("Index");
        }
    }
}