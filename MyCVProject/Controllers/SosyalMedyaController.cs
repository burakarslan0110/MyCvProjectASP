using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCVProject.Models.Entity;
using MyCVProject.Repositories;

namespace MyCVProject.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<SosyalMedya> sosrepo = new GenericRepository<SosyalMedya>();
        public ActionResult Index()
        {
            var sosyalmedya = sosrepo.List();
            return View(sosyalmedya);
        }

        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SosyalMedyaEkle(SosyalMedya p)
        {
            sosrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaDuzenle(int id)
        {
            SosyalMedya t = sosrepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult SosyalMedyaDuzenle(SosyalMedya p)
        {
            SosyalMedya t = sosrepo.Find(x => x.ID == p.ID);
            t.Durum = true;
            t.Ad = p.Ad;
            t.Link = p.Link;
            t.Ikon = p.Ikon;
            sosrepo.TUpdate(t);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaPasiflestir(int id)
        {
            var hesap = sosrepo.Find(x => x.ID == id);
            hesap.Durum = false;
            sosrepo.TUpdate(hesap);
            return RedirectToAction("Index");

        }
    }
}