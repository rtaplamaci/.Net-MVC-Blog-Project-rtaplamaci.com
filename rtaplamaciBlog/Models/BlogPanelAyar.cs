using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rtaplamaciBlog.Models
{
    public class BlogPanelAyar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MDescripton { get; set; }
        public string MAuthor { get; set; }
        public string MUrl { get; set; }
        public string MKeywords { get; set; }
        public string STitle { get; set; }
    }
}