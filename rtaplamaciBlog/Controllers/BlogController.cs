using rtaplamaciBlog.Models;
using rtaplamaciBlog.Models.ContextMenager;
using rtaplamaciBlog.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Controllers
{
    public class BlogController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (DBEntities db = new DBEntities())
            {
                VMBlogListe model = new VMBlogListe();
                model.BlogPanelAyar = db.BlogPanelAyarlari.FirstOrDefault();
                model.Yazilar = db.BlogYazilari.Where(x => x.YayinlansinMi == true).OrderByDescending(x => x.Id).ToList();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Detay(int id = 0)
        {
            using (DBEntities db = new DBEntities())
            {
                VMBlogDetay model = new VMBlogDetay();
                model.Yazi = db.BlogYazilari.Where(x => x.Id == id && x.YayinlansinMi == true).FirstOrDefault();
                model.Oneri = db.BlogYazilari.Where(x => x.Id != id).OrderByDescending(x => x.Id).Take(4).ToList();
                if (model.Yazi == null)
                {
                    return RedirectToAction("Index", "NotFound");
                }
                return View(model);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Onizleme(int id = 0)
        {
            using (DBEntities db = new DBEntities())
            {
                VMBlogDetay model = new VMBlogDetay();
                model.Yazi = db.BlogYazilari.Where(x => x.Id == id).FirstOrDefault();
                model.Oneri = db.BlogYazilari.Where(x => x.Id != id).OrderByDescending(x => x.Id).Take(4).ToList();
                if (model.Yazi == null)
                {
                    return RedirectToAction("Index", "NotFound");
                }
                return View(model);
            }
        }
    }
}