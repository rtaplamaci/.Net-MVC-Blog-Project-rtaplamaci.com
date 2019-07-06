using rtaplamaciBlog.Models.ContextMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Controllers
{
    public class IletisimController : Controller
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
        public ActionResult Index(string adSoyad, string eMail, string Mesaj)
        {
            using (DBEntities db = new DBEntities())
            {
                var model = db.KullaniciAyarlari.FirstOrDefault();
                MailMessage mail = new MailMessage(model.Email, model.Email);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                mail.Subject = "Blog İletişim Paneli";
                mail.IsBodyHtml = true;

                mail.Body = "<html><html><body><p>Ad: " + adSoyad + "</p><p>Email: " + eMail + "</p><p>Mesaj:</p><p>" + Mesaj + "</p></body></html>";
                client.Credentials = new NetworkCredential(model.Email, model.EmailSifre);
                client.Send(mail);
                TempData["Basarili"] = "Mesajınız başırlı bir şekilde gönderildi. Gerekli görülmesi durumunda en kısa süre içerisinde size geri dönüş yapılacaktır.";
                return RedirectToAction("Index");
            }
        }
    }
}
