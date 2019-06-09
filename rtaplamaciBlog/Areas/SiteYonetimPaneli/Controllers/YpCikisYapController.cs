using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace rtaplamaciBlog.Areas.SiteYonetimPaneli.Controllers
{
    public class YpCikisYapController : Controller
    {
        // GET: SiteYonetimPaneli/YpCikisYap

        [Authorize]
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "YpGirisYap");
        }
    }
}