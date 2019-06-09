using rtaplamaciBlog.Models;
using rtaplamaciBlog.Models.ContextMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace rtaplamaciBlog.Areas.SiteYonetimPaneli.Controllers
{
    public class YpGirisYapController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Request.Cookies["us"] != null)
            {
                ViewData["kullaniciAdi"] = Request.Cookies["us"].Value.ToString();
                ViewData["kullanicicheckBox"] = "checked";
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(string KullaniciAdi, string KullaniciSifre, string KullaniciAdimiHatirla)
        {
            using (DBEntities db = new DBEntities())
            {
                string kad = MD5Sifrele(KullaniciAdi), ksifre = MD5Sifrele(KullaniciSifre);
                KullaniciAyar model = new KullaniciAyar();
                model = db.KullaniciAyarlari.Where(x => x.KullaniciAdi == kad && x.Sifre == ksifre).FirstOrDefault();

                if (model != null)
                {
                    FormsAuthentication.SetAuthCookie(model.KullaniciAdi, false);

                    if (KullaniciAdimiHatirla != null)
                    {
                        HttpCookie cookie = new HttpCookie("us", KullaniciAdi);
                        cookie.Expires = DateTime.Now.AddDays(300);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        //Cockie olup olmadığını kontrol edemiyor
                        if (Request.Cookies["us"] != null)
                        {
                            Response.Cookies["us"].Expires = DateTime.Now.AddDays(-1);
                        }
                    }
                    return RedirectToAction("Index", "YpAnasayfa");
                }
                else
                {
                    TempData["Message"] = "Kullanıcı bilgileriniz hatalı veya Güvenlik prosedürlerini tamamlarken hatalı işlem yaptınız. Lütfen tekrar deneyin.";
                    return RedirectToAction("Index");
                }

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
