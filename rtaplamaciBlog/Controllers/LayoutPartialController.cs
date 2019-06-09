using rtaplamaciBlog.Models.ContextMenager;
using rtaplamaciBlog.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Controllers
{
    public class LayoutPartialController : Controller
    {
        [HttpGet]
        public PartialViewResult Header()
        {
            using (DBEntities db = new DBEntities())
            {
                VMPartialHeader model = new VMPartialHeader();
                model.LGorselAciklama = db.LGorselAciklamaAyarlari.FirstOrDefault();
                model.SosyalMedya = db.SosyalMedyaAyarlari.OrderBy(x => x.Sira).ToList();
                model.Menu = db.MenuAyarlari.OrderBy(x => x.Sira).ToList();
                return PartialView("~/Views/_Shared/_LayoutHeader.cshtml", model); 
            }
        }

        [HttpGet]
        public PartialViewResult Fotter()
        {
            using (DBEntities db = new DBEntities())
            {
                VMPartialFotter model = new VMPartialFotter();
                model.FotterAciklama = db.FotterAciklamaAyarlari.FirstOrDefault();
                model.FaydaliLinkler = db.FaydaliLinklerAyarlari.OrderBy(x => x.Sira).ToList();
                model.SosyalMedya = db.SosyalMedyaAyarlari.OrderBy(x => x.Sira).ToList();
                return PartialView("~/Views/_Shared/_LayoutFotter.cshtml", model); 
            }
        }
    }
}