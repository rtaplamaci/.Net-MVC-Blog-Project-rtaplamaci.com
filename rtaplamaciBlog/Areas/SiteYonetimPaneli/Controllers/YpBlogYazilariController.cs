using rtaplamaciBlog.Models;
using rtaplamaciBlog.Models.ContextMenager;
using rtaplamaciBlog.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Areas.SiteYonetimPaneli.Controllers
{
    [Authorize]
    public class YpBlogYazilariController : Controller
    {
        [HttpGet]
        public ActionResult PanelAyarlari()
        {
            using (DBEntities db = new DBEntities())
            {
                var model = db.BlogPanelAyarlari.FirstOrDefault();
                return View(model); 
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PanelAyarlari(BlogPanelAyar blogPanelAyar)
        {
            using (DBEntities db = new DBEntities())
            {
                blogPanelAyar.Id = 1;
                db.Entry(blogPanelAyar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return View(blogPanelAyar); 
            }
        }

        [HttpGet]
        public ActionResult Liste()
        {
            using (DBEntities db = new DBEntities())
            {
                List<BlogYazilari> model = new List<BlogYazilari>();
                model = db.BlogYazilari.OrderByDescending(x => x.Id).ToList();
                return View(model); 
            }
        }

        [HttpGet]
        public ActionResult Yayinla(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                BlogYazilari blogYazilari = new BlogYazilari();
                blogYazilari = db.BlogYazilari.Find(id);
                blogYazilari.YayinlansinMi = !blogYazilari.YayinlansinMi;
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("Liste"); 
            }
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                db.BlogYazilari.Remove(db.BlogYazilari.Find(id));
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("Liste"); 
            }
        }


        [HttpGet]
        public ActionResult Detay(int id = 0)
        {
            using (DBEntities db = new DBEntities())
            {
                BlogYazilari model = new BlogYazilari();
                if (id > 0)
                {
                    model = db.BlogYazilari.Find(id);
                }
                else
                {
                    model.Tarih = DateTime.Now;
                    model.NGDizin = "NG.jpg";
                    model.MGDizin = "MG.jpg";
                }
                return View(model); 
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Detay(BlogYazilari blogYazilari, HttpPostedFileBase fileN, HttpPostedFileBase fileM)
        {
            using (DBEntities db = new DBEntities())
            {
                if (fileN != null)
                {
                    if (Path.GetExtension(fileN.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(fileN.FileName).ToLower() == ".png"
                            || Path.GetExtension(fileN.FileName).ToLower() == ".gif"
                            || Path.GetExtension(fileN.FileName).ToLower() == ".jpeg")
                    {
                        var myUniqueFileName = string.Format(@"{0}{1}", Guid.NewGuid(), Path.GetExtension(fileN.FileName)).ToLower();
                        blogYazilari.NGDizin = Path.GetFileNameWithoutExtension(fileN.FileName) + "_" + myUniqueFileName;
                        var path = Path.Combine(Server.MapPath("~/Images/BlogContent/Normal"), blogYazilari.NGDizin);
                        fileN.SaveAs(path);
                    }
                    else
                    {
                        TempData["Uyari"] = "Normal Görselin formatı jpg, png, gif, jpeg olabilir!";
                        return View(blogYazilari);
                    }
                }

                if (fileM != null)
                {
                    if (Path.GetExtension(fileM.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(fileM.FileName).ToLower() == ".png"
                            || Path.GetExtension(fileM.FileName).ToLower() == ".gif"
                            || Path.GetExtension(fileM.FileName).ToLower() == ".jpeg")
                    {
                        var myUniqueFileName = string.Format(@"{0}{1}", Guid.NewGuid(), Path.GetExtension(fileM.FileName)).ToLower();
                        blogYazilari.MGDizin = Path.GetFileNameWithoutExtension(fileM.FileName) + "_" + myUniqueFileName;
                        var path = Path.Combine(Server.MapPath("~/Images/BlogContent/Mini"), blogYazilari.MGDizin);
                        fileM.SaveAs(path);
                    }
                    else
                    {
                        TempData["Uyari"] = "Mini Görselin formatı jpg, png, gif, jpeg olabilir!";
                        return View(blogYazilari);
                    }
                }

                if (blogYazilari.Id > 0)
                {
                    db.Entry(blogYazilari).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.BlogYazilari.Add(blogYazilari);
                }
                db.SaveChanges();
                TempData["Mesaj"] = "Blog yazınızı yayına almayı unutmayın!";
                return RedirectToAction("Liste"); 
            }
        }
    }
}