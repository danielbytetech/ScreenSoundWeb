namespace ScreenSoundWeb.Models
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Avaliacao
    {
        public Avaliacao()
        {

        }
        public Avaliacao(int nota)
        {
            Nota = nota;
        }

        public int Id { get; set; }
        public double Nota { get; set; }
        public int BandaId { get; set; }
        public Banda Banda { get; set; }
        

        public static Avaliacao Parse(string texto)
        {
            int nota = int.Parse(texto);
            return new Avaliacao(nota);
        }
    }
}
