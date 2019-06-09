using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Models
{
    public class AnasayfaAyar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MDescripton { get; set; }
        public string MAuthor { get; set; }
        public string MUrl { get; set; }
        public string MKeywords { get; set; }
        public string STitle { get; set; }
        public string GDizin { get; set; }
        public string GAlt { get; set; }
        public string BBaslik { get; set; }
        public string IBaslik { get; set; }
        public string SBaslik { get; set; }
        [AllowHtml]
        public string Icerik { get; set; }
    }
}