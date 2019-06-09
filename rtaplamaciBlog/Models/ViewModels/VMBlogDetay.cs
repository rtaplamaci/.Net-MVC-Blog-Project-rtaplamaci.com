using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rtaplamaciBlog.Models.ViewModels
{
    public class VMBlogDetay
    {
        public BlogYazilari Yazi { get; set; }
        public List<BlogYazilari> Oneri { get; set; }
    }
}