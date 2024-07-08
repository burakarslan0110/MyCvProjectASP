using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCVProject.Models.Entity; 

namespace MyCVProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        CvDbEntities db = new CvDbEntities(); //entity nesnesi türetme
        public ActionResult Index()
        {
            var hakkimda = db.Hakkimda.ToList();
            return View(hakkimda);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.SosyalMedya.Where(x => x.Durum == true).ToList(); ;
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyim = db.Deneyimlerim.ToList();
            return PartialView(deneyim);
        }
        public PartialViewResult Egitim()
        {
            var egitim = db.Egitimlerim.ToList();
            return PartialView(egitim);
        }

        public PartialViewResult Yetenek()
        {
            var yetenek = db.Yeteneklerim.ToList();
            return PartialView(yetenek);   
        }
        public PartialViewResult Proje()
        {
            var proje = db.Projelerim.ToList();
            return PartialView(proje);
        }

        public PartialViewResult Sertifika()
        {
            var sertifika = db.Sertifikalarim.ToList(); 
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Iletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString()); 
            db.Iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}