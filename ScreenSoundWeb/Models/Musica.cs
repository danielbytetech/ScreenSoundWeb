namespace ScreenSoundWeb.Models
{

    using System;
    using System.Collections.Generic;

    public class Musica 
    {
        public Musica()
        {

        }
        public Musica(Banda artista, string nome)
        {
            Artista = artista;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; }
        public Banda Artista { get; }
        public int Duracao { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public bool Disponivel { get; set; }

        public string DescriçãoResumida => $"A musica {Nome} pertence a banda {Artista}";

        public void ExibirFichaTecnica()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Artista: {Artista.Nome}");
            Console.WriteLine($"Duração: {Duracao}");
            Console.WriteLine($"Disponivel: {Disponivel}");
            if (Disponivel == true)
            {
                Console.WriteLine("Disponivel no plano.\n");
            }
            else
            {
                Console.WriteLine("Adquira o plano Plus+\n");
            }
        }
    }
}
