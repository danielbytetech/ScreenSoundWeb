namespace ScreenSoundWeb.Models
{

    using System;
    using System.Collections.Generic;

    public class Musica
    {
        // Construtor, tecla de atalho Ctrl + TAB
        public Musica(Banda artista, string nome)
        {
            Artista = artista;
            Nome = nome;
        }

        // Atributos de uma classe
        // Ctrl + R + Ctrl + R renomeia alterando todos com o mesmo nome
        // Para criar uma Propriedade basta prop + TAB
        public string Nome { get; }
        public Banda Artista { get; }
        public int Duracao { get; set; }

        //tem operação de escrita e leitura, então não precisa de voids
        public bool Disponivel { get; set; }

        public Genero Genero { get; set; }

        // Lambda
        public string DescriçãoResumida => $"A musica {Nome} pertence a banda {Artista}";

        // Metodo para exibir a ficha com retorno void
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

    public class Genero
    {
        public string Nome { get; set; }
    }
}


// Aulas

//Aula 2
//class Conta
//{
//    public string titular { get; set; }
//    public int idConta { get; set; }
//    public double saldo { get; set; }
//    public int senha { get; set; }

//    public void exibirInformacoes()
//    {
//        Console.WriteLine("INFORMAÇÕES DA CONTA:");
//        Console.WriteLine($"Titular: {titular}");
//        Console.WriteLine($"Saldo atual: {this.saldo}");
//    }
//    // na lambda a operação => da expressão pode ser definida nesse caso como um return de um valor denominado depois da operação
//    public int Somar(int a, int b) => a + b;
//}

//class Carro
//{
//    public string Fabricante { get; set; }
//    public string Modelo { get; set; }
//    public int Ano { get => Ano;
//        set { 
//            if(value < 1960 || value > 2023)
//            {
//                Console.WriteLine("Valor inválido, insira um ano entre 1960 e 2023");
//            }
//            else
//            {
//                Ano = value;
//            }
//        } 
//    }
//    public int QuantidadePortas { get; set; }
//    public int velocidade = 0;
//    public string DescricaoDetalhada => $"Modelo do Carro: {Fabricante}, {Modelo}, {Ano}";

//    public void exibirInformacoes()
//    {
//        Console.WriteLine($"Informações do carro: {this.Fabricante} {this.Modelo}, {this.QuantidadePortas} portas, {this.Ano}");
//    }

//    public void acelerar()
//    {
//        Console.WriteLine("Acelerando...");
//        if (velocidade < 100)
//        {
//            velocidade = velocidade + 5;
//        }
//    }

//    public void frear()
//    {
//        Console.WriteLine("Freando...");
//        if (velocidade > 0)
//        {
//            velocidade = velocidade - 5;
//        }
//    }

//    public void buzinar()
//    {
//        Console.WriteLine("Bi Bi");
//    }
//}

//class Produto
//{
//    private double preco;
//    private int estoque;
//    public string nome;
//    public string marca;
//    public double Preco {
//        get => preco; 
//        set {
//            if (value <= 0)
//            {
//                preco = value;
//            }
//            else
//            {
//                preco = 10;
//            }
//        } 
//    } 
//    public int Estoque
//    {
//        get => estoque;
//        set
//        {
//            if (value > 0)
//            {
//                estoque = value;
//            }
//            else
//            {
//                estoque = 0;
//            }
//        }
//    }
//    public string DescricaoProduto => $"Produto: {nome}, {marca}, {Preco}, {Estoque}";

//}

//Aula 4
//class Titular
//{
//    public Titular(string nome, string cpf, string endereco)
//    {
//        Nome = nome;
//        Cpf = cpf;
//        Endereco = endereco;
//    }

//    public string Nome { get; }
//    public string Cpf { get; }
//    public string Endereco { get; }
//}


//class Conta
//{
//    public Conta(Titular titular, int agencia, int numeroDaConta, double saldo, double limite)
//    {
//        Titular = titular;
//        Agencia = agencia;
//        NumeroDaConta = numeroDaConta;
//        Saldo = saldo;
//        Limite = limite;
//    }

//    public Titular Titular { get; }
//    public int Agencia { get; }
//    public int NumeroDaConta { get; }
//    public double Saldo { get; }
//    public double Limite { get; }

//    public string Informacoes => $"Conta nº {this.NumeroDaConta}, Agência {this.Agencia}, Titular: {this.Titular.Nome} - Saldo: {this.Saldo}";


//    public void ExibirInformacoes()
//    {
//        Console.WriteLine($"Informacoes da Conta: {Informacoes}");
//    }
//}

//class Jogo
//{
//    public Jogo(string nome, string genero, int anoLancamento)
//    {
//        Nome = nome;
//        Genero = genero;
//        AnoLancamento = anoLancamento;
//    }

//    public string Nome { get; set; }
//    public string Genero { get; set; }
//    public int AnoLancamento { get; set; }

//}

//class CatalagoJogos
//{
//    private List<Jogo> Jogos { get; set; }

//    // Propriedade que retorna se o catalogo esta vazio
//    public bool CatalagoVazio => Jogos.Count == 0;

//    // Construtor para inicializar o catalogo de jogos vazio
//    public CatalagoJogos()
//    {
//        Jogos = new List<Jogo>();
//    }

//    // Método para adicionar um jogo ao catálogo
//    public void AdicionarJogo(string nome, string genero, int anoLancamento)
//    {
//        Jogo novojogo = new Jogo(nome, genero, anoLancamento);
//        Jogos.Add(novojogo);
//        Console.WriteLine($"Jogo /{nome}/ adicionadao ao catalago.");
//    }

//    // Método para listar todos os jogos no catálogo
//    public void ListarJogos()
//    {
//        if (CatalagoVazio)
//        {
//            Console.WriteLine("O catalogo de jogos esta vazio");
//        }
//        else
//        {
//            Console.WriteLine("Catalogo de Jogos:");
//            foreach (var jogo in Jogos)
//            {
//                Console.WriteLine($"Nome: {jogo.Nome}, Genero: {jogo.Genero}, Ano de Lançamento: {jogo.AnoLancamento}");
//            }
//        }
//    }
//}
