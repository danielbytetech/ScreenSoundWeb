using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenSoundWeb.Models
{
    public class BandaDetalhesViewModel 
    {
        public bool BandaEncontrada { get; set; }
        public string NomeBanda { get; set; } 
        public string Mensagem { get; set; }
        public double Media { get; set; }        
        public List<AlbumViewModel> Discografia { get; set; }
    }
}
