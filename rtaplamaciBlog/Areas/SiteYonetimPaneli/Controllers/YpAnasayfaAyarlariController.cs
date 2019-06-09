using rtaplamaciBlog.Models;
using rtaplamaciBlog.Models.ContextMenager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Areas.SiteYonetimPaneli.Controllers
{
    [Authorize]
    public class YpAnasayfaAyarlariController : Controller
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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(AnasayfaAyar anasayfaAyar, HttpPostedFileBase file)
        {
            using (DBEntities db = new DBEntities())
            {
                anasayfaAyar.Id = 1;
                if (file != null)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(file.FileName).ToLower() == ".png"
                            || Path.GetExtension(file.FileName).ToLower() == ".gif"
                            || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        var myUniqueFileName = string.Format(@"{0}{1}", Guid.NewGuid(), Path.GetExtension(file.FileName)).ToLower();
                        anasayfaAyar.GDizin = Path.GetFileNameWithoutExtension(file.FileName) + "_" + myUniqueFileName;
                        var path = Path.Combine(Server.MapPath("~/Images/General"), anasayfaAyar.GDizin);
                        file.SaveAs(path);
                    }
                    else
                    {
                        TempData["Uyari"] = "Görselin formatı jpg, png, gif, jpeg olabilir!";
                        return View(anasayfaAyar);
                    }
                }
                db.Entry(anasayfaAyar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return View(anasayfaAyar);
            }
        }
    }
}