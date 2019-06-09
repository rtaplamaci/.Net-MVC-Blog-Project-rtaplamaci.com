using rtaplamaciBlog.Models;
using rtaplamaciBlog.Models.ContextMenager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Areas.SiteYonetimPaneli.Controllers
{
    [Authorize]
    public class YpAyarlarController : Controller
    {
        [HttpGet]
        public ActionResult LayoutGorselAciklama()
        {
            using (DBEntities db = new DBEntities())
            {
                var model = db.LGorselAciklamaAyarlari.FirstOrDefault();
                return View(model);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LayoutGorselAciklama(LGorselAciklamaAyar lGorselAciklamaAyar, HttpPostedFileBase file)
        {
            using (DBEntities db = new DBEntities())
            {
                lGorselAciklamaAyar.Id = 1;
                if (file != null)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(file.FileName).ToLower() == ".png"
                            || Path.GetExtension(file.FileName).ToLower() == ".gif"
                            || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        var myUniqueFileName = string.Format(@"{0}{1}", Guid.NewGuid(), Path.GetExtension(file.FileName)).ToLower();
                        lGorselAciklamaAyar.GDizin = Path.GetFileNameWithoutExtension(file.FileName) + "_" + myUniqueFileName;
                        var path = Path.Combine(Server.MapPath("~/Images/General"), lGorselAciklamaAyar.GDizin);
                        file.SaveAs(path);
                    }
                    else
                    {
                        TempData["Uyari"] = "Görselin formatı jpg, png, gif, jpeg olabilir!";
                        return View(lGorselAciklamaAyar);
                    }
                }
                db.Entry(lGorselAciklamaAyar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return View(lGorselAciklamaAyar); 
            }
        }

        [HttpGet]
        public ActionResult SosyalMedya()
        {
            using (DBEntities db = new DBEntities())
            {
                List<SosyalMedyaAyar> model = new List<SosyalMedyaAyar>();
                model = db.SosyalMedyaAyarlari.OrderBy(x => x.Sira).ToList();
                return View(model); 
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SosyalMedya(SosyalMedyaAyar sosyalMedyaAyar)
        {
            using (DBEntities db = new DBEntities())
            {
                db.SosyalMedyaAyarlari.Add(sosyalMedyaAyar);
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("SosyalMedya"); 
            }
        }

        [HttpGet]
        public ActionResult SosyalMedyaSil(int id = 0)
        {
            using (DBEntities db = new DBEntities())
            {
                db.SosyalMedyaAyarlari.Remove(db.SosyalMedyaAyarlari.Find(id));
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("SosyalMedya"); 
            }
        }

        [HttpGet]
        public ActionResult Menuler()
        {
            using (DBEntities db = new DBEntities())
            {
                List<MenuAyar> model = new List<MenuAyar>();
                model = db.MenuAyarlari.OrderBy(x => x.Sira).ToList();
                return View(model); 
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Menuler(MenuAyar menuAyar)
        {
            using (DBEntities db = new DBEntities())
            {
                db.MenuAyarlari.Add(menuAyar);
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("Menuler"); 
            }
        }

        [HttpGet]
        public ActionResult MenulerSil(int id = 0)
        {
            using (DBEntities db = new DBEntities())
            {
                db.MenuAyarlari.Remove(db.MenuAyarlari.Find(id));
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("Menuler"); 
            }
        }

        [HttpGet]
        public ActionResult FooterAciklamasi()
        {
            using (DBEntities db = new DBEntities())
            {
                var model = db.FotterAciklamaAyarlari.FirstOrDefault();
                return View(model); 
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult FooterAciklamasi(FotterAciklamaAyar fotterAciklamaAyar)
        {
            using (DBEntities db = new DBEntities())
            {
                fotterAciklamaAyar.Id = 1;
                db.Entry(fotterAciklamaAyar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("FooterAciklamasi"); 
            }
        }

        [HttpGet]
        public ActionResult FaydaliLinkler()
        {
            using (DBEntities db = new DBEntities())
            {
                List<FaydaliLinklerAyar> model = new List<FaydaliLinklerAyar>();
                model = db.FaydaliLinklerAyarlari.OrderBy(x => x.Sira).ToList();
                return View(model); 
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult FaydaliLinkler(FaydaliLinklerAyar faydaliLinklerAyar)
        {
            using (DBEntities db = new DBEntities())
            {
                db.FaydaliLinklerAyarlari.Add(faydaliLinklerAyar);
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("FaydaliLinkler"); 
            }
        }

        [HttpGet]
        public ActionResult FaydaliLinklerSil(int id = 0)
        {
            using (DBEntities db = new DBEntities())
            {
                db.FaydaliLinklerAyarlari.Remove(db.FaydaliLinklerAyarlari.Find(id));
                db.SaveChanges();
                TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                return RedirectToAction("FaydaliLinkler"); 
            }
        }

        [HttpGet]
        public ActionResult FavIcon()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult FavIcon(HttpPostedFileBase FavIcon)
        {
            if (FavIcon != null)
            {
                if (System.IO.File.Exists("~/Images/General/favicon.png"))
                {
                    System.IO.File.Delete("~/Images/General/favicon.png");
                }
                if (Path.GetExtension(FavIcon.FileName).ToLower() == ".jpg"
                    || Path.GetExtension(FavIcon.FileName).ToLower() == ".png"
                    || Path.GetExtension(FavIcon.FileName).ToLower() == ".gif"
                    || Path.GetExtension(FavIcon.FileName).ToLower() == ".jpeg")
                {
                    FavIcon.SaveAs(Server.MapPath("~/Images/General/favicon.png"));
                    TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                }
                else
                {
                    TempData["Uyari"] = "Görselin formatı jpg, png, gif, jpeg olabilir!";
                }
            }
            else
            {
                TempData["Uyari"] = "İşlem yapmadan önce görsel seçmelisiniz!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult KullaniciMail()
        {
            using (DBEntities db = new DBEntities())
            {
                var model = db.KullaniciAyarlari.FirstOrDefault();
                return View(model); 
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KullaniciAyar(KullaniciAyar kullaniciAyar, string ESifre)
        {
            using (DBEntities db = new DBEntities())
            {
                KullaniciAyar model = new KullaniciAyar();
                model = db.KullaniciAyarlari.FirstOrDefault();
                if (model.Sifre == MD5Sifrele(ESifre))
                {
                    model.KullaniciAdi = MD5Sifrele(kullaniciAyar.KullaniciAdi);
                    model.Sifre = MD5Sifrele(kullaniciAyar.Sifre);
                    db.SaveChanges();
                    TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                }
                else
                {
                    TempData["Uyari"] = "Belirtmiş olduğunuz kullanıcı şifresi hatalı. Lütfen tekrar deneyin!";
                }
                return RedirectToAction("KullaniciMail"); 
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult MailAyar(KullaniciAyar kullaniciAyar, string KSifre)
        {
            using (DBEntities db = new DBEntities())
            {
                KullaniciAyar model = new KullaniciAyar();
                model = db.KullaniciAyarlari.FirstOrDefault();
                if (model.Sifre == MD5Sifrele(KSifre))
                {
                    model.Email = kullaniciAyar.Email;
                    model.EmailSifre = kullaniciAyar.EmailSifre;
                    db.SaveChanges();
                    TempData["Basarili"] = "İşlem başırılı bir şekilde gerçekleştirildi!";
                }
                else
                {
                    TempData["Uyari"] = "Belirtmiş olduğunuz kullanıcı şifresi hatalı. Lütfen tekrar deneyin!";
                }
                return RedirectToAction("KullaniciMail"); 
            }
        }

        public static string MD5Sifrele(string sifrelenecekMetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

    }
}
