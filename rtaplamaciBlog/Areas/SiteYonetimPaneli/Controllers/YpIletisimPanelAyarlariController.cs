using rtaplamaciBlog.Models;
using rtaplamaciBlog.Models.ContextMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Areas.SiteYonetimPaneli.Controllers
{
    [Authorize]
    public class YpIletisimPanelAyarlariController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (DBEntities db = new DBEntities())
            {
                var model = db.IletisimAyarlar.FirstOrDefault();
                return View(model); 
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(IletisimAyar iletisimAyar)
        {
            using (DBEntities db = new DBEntities())
            {
                iletisimAyar.Id = 1;
                db.Entry(iletisimAyar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return View(iletisimAyar); 
            }
        }
    }
}