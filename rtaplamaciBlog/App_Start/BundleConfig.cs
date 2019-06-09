using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace rtaplamaciBlog.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Content/jquery/jquery.min.js",
                "~/Content/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/jquery-easing/jquery.easing.min.js",
                "~/Content/js/resume.js",
                "~/Content/prism/prism.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap/css/bootstrap.min.css",
                "~/Content/devicons/css/devicons.min.css",
                "~/Content/simple-line-icons/css/simple-line-icons.css",
                "~/Content/css/resume.css",
                "~/Content/prism/prism.css"
                ));
        }
    }
}