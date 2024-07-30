namespace ScreenSoundWeb.Models
{

    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Banda : IAvaliavel
    {
        public Banda()
        {
            Albuns = new List<Album>();
            Notas = new List<Avaliacao>();
        }

        public Banda(string nome) : this()
        {
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        
        public double Media
        {
            get
            {
                if (Notas.Count == 0) return 0;
                else return Notas.Average(a => a.Nota);
            }            
        }
        public ICollection<Album> Albuns { get; set; }
        public ICollection<Avaliacao> Notas { get; set; }


        public void AdicionarNota(Avaliacao nota)
        {
            Notas.Add(nota);
        }

        public void AdicionarAlbum(Album album)
        {
            Albuns.Add(album);
        }

        public void ExibirDiscografia()
        {
            Console.WriteLine($"Discografia da banda {Nome}");
            foreach (Album album in Albuns)
            {
                Console.WriteLine($"Album: {album.Nome} ({album.DuracaoTotal})");
            }
        }
    }
}