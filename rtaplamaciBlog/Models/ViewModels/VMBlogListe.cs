using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rtaplamaciBlog.Models.ViewModels
{
    public class VMBlogListe
    {
        public BlogPanelAyar BlogPanelAyar { get; set; }
        public List<BlogYazilari> Yazilar { get; set; }
    }
}