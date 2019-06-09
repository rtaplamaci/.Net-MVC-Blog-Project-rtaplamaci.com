using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rtaplamaciBlog.Models
{
    public class MenuAyar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Adi { get; set; }
        public int Sira { get; set; }
        public string Url { get; set; }
    }
}