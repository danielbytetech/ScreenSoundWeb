namespace ScreenSoundWeb.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Album : IAvaliavel
    {
        public Album()
        {
            Musicas = new List<Musica>();
            Notas = new List<Avaliacao>();
        }
        public Album(string nome) : this()
        {
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int DuracaoTotal => Musicas.Sum(m => m.Duracao);
        public double Media
        {
            get
            {
                if (Notas.Count == 0) return 0;
                else return Notas.Average(nota => nota.Nota);
            }
        }
        public int BandaId { get; set; }
        public Banda Banda { get; set; }

        public ICollection<Musica> Musicas { get; set; }
        public ICollection<Avaliacao> Notas { get; set; }



        public void AdicionarMusica(Musica musica)
        {
            Musicas.Add(musica);
        }

        public void AdicionarNota(Avaliacao nota)
        {
            Notas.Add(nota);
        }

        public void ExibirMusicasDoAlbum()
        {
            Console.WriteLine($"Lista de músicas do Album {Nome}:\n");
            foreach (var musica in Musicas)
            {
                Console.WriteLine($"Musica: {musica.Nome}");
            }
            Console.WriteLine($"\nPara ouvir esse Album inteiro você precisa de {DuracaoTotal}");
        }
    }
}