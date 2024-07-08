using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCVProject.Models.Entity;
using MyCVProject.Repositories;

namespace MyCVProject.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository ytnkrepo = new YetenekRepository(); //bu nesne GenericRepository'deki CRUD metodlarını miras aldı. 
        public ActionResult Index()
        {
            var degerler = ytnkrepo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(Yeteneklerim p)
        {
            ytnkrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            Yeteneklerim t = ytnkrepo.Find(x => x.ID == id);
            ytnkrepo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            Yeteneklerim t = ytnkrepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekGetir(Yeteneklerim p)
        {
            Yeteneklerim t = ytnkrepo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
            ytnkrepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}