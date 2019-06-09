using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Models
{
    public class LGorselAciklamaAyar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GDizin { get; set; }
        public string GAlt { get; set; }
        [AllowHtml]
        public string Aciklama { get; set; }
        [AllowHtml]
        public string MAciklama { get; set; }
    }
}