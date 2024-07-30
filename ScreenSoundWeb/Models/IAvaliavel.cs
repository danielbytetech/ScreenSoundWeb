using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenSoundWeb.Models
{
    interface IAvaliavel
    {
        double Media { get; }
        void AdicionarNota(Avaliacao nota);
    }
}
