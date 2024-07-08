using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCVProject.Models.Entity;
using MyCVProject.Repositories;

namespace MyCVProject.Controllers
{
    public class ProjeController : Controller
    {
        GenericRepository<Projelerim> prorepo = new GenericRepository<Projelerim>();
        // GET: Proje
        public ActionResult Index()
        {
            var proje = prorepo.List();
            return View(proje);
        }

        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjeEkle(Projelerim p)
        {
            prorepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult ProjeSil(int id)
        {
            Projelerim t = prorepo.Find(x => x.ID == id);
            prorepo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProjeGetir(int id)
        {
            Projelerim t = prorepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult ProjeGetir(Projelerim p)
        {
            Projelerim t = prorepo.Find(x => x.ID == p.ID);
            t.Aciklama1 = p.Aciklama1;
            t.Baslik = p.Baslik;
            t.Baglantı = p.Baglantı;
            prorepo.TUpdate(t);
            return RedirectToAction("Index");
        }




    }
}