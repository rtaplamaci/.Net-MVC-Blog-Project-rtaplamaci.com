using rtaplamaciBlog.Models.ContextMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Controllers
{
    public class AnasayfaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (DBEntities db = new DBEntities())
            {
                var model = db.AnasayfaAyarlar.FirstOrDefault();
                return View(model);
            }
        }
    }
}