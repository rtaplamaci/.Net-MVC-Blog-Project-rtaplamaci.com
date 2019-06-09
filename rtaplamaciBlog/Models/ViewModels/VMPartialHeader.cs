using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rtaplamaciBlog.Models.ViewModels
{
    public class VMPartialHeader
    {
        public LGorselAciklamaAyar LGorselAciklama { get; set; }
        public List<SosyalMedyaAyar> SosyalMedya { get; set; }
        public List<MenuAyar> Menu { get; set; }
    }
}