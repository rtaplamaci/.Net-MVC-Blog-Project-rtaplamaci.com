using System.Web.Mvc;

namespace rtaplamaciBlog.Areas.SiteYonetimPaneli
{
    public class SiteYonetimPaneliAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SiteYonetimPaneli";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SiteYonetimPaneli_default",
                "SiteYonetimPaneli/{controller}/{action}/{id}",
                new { controller = "YpGirisYap", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}