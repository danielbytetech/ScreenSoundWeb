namespace ScreenSoundWeb.Models
{

    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Banda
    {
        private List<Album> albuns = new List<Album>();
        private List<Avaliacao> notas = new List<Avaliacao>();

        public Banda(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }
        public double Media
        {
            get
            {
                if (notas.Count == 0) return 0;
                else return notas.Average(a => a.Nota);
            }
        }
        public List<Album> Albuns => albuns;


        public void AdicionarNota(Avaliacao nota)
        {
            notas.Add(nota);
        }

        public void AdicionarAlbum(Album album)
        {
            albuns.Add(album);
        }

        public void ExibirDiscografia()
        {
            Console.WriteLine($"Discografia da banda {Nome}");
            foreach (Album album in albuns)
            {
                Console.WriteLine($"Album: {album.Nome} ({album.DuracaoTotal})");
            }
        }
    }
}