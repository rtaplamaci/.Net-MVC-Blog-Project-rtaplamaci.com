using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rtaplamaciBlog.Models.ViewModels
{
    public class VMPartialFotter
    {
        public FotterAciklamaAyar FotterAciklama { get; set; }
        public List<FaydaliLinklerAyar> FaydaliLinkler { get; set; }
        public List<SosyalMedyaAyar> SosyalMedya { get; set; }
    }
}