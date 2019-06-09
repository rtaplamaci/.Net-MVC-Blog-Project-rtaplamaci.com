using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rtaplamaciBlog.Models
{
    public class SosyalMedyaAyar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Icon { get; set; }
        public int Sira { get; set; }
        public string Url { get; set; }
    }
}