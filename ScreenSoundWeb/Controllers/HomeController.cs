using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ScreenSoundWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ScreenSoundWeb.Data;

namespace ScreenSoundWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _bandasRegistradas;

        public HomeController(ApplicationDbContext bandasRegistradas)
        {
            _bandasRegistradas = bandasRegistradas;
        }

        public bool BandaExiste(string nomeBanda)
        { 
           return _bandasRegistradas.Bandas.Any(b => b.Nome == nomeBanda);            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult RegistrarBanda()
        {
            return View();
        }

        public IActionResult CriarBanda(string nomeBanda)
        {
            if (string.IsNullOrWhiteSpace(nomeBanda))
            {
                TempData["CampoVazio"] = "Preencha o campo!";
                return RedirectToAction("RegistrarBanda");
            }
            
            string nomeBandaTrimmed = nomeBanda.Trim();
            
            if (BandaExiste(nomeBandaTrimmed))
            {
                TempData["MesmoNome"] = "Esse valor ja foi digitado, digite outro valor";
                return RedirectToAction("RegistrarBanda");
            }
            
            Banda novaBanda = new Banda(nomeBandaTrimmed);
            _bandasRegistradas.Bandas.Add(novaBanda);
            _bandasRegistradas.SaveChanges();
            TempData["Confirmado"] = "A Banda foi registrada";

            return RedirectToAction("RegistrarBanda");
        }

        [HttpPost]
        public IActionResult VerificarBandaParaAlbum(string nomeBanda)
        {
            if (string.IsNullOrWhiteSpace(nomeBanda))
            {
                TempData["CampoVazio"] = "Preencha o Campo!";
                TempData["BandaEncontrada"] = false;
                return RedirectToAction("RegistrarAlbum");
            }

            string nome = nomeBanda.Trim();
            
            if (BandaExiste(nome))
            {
                TempData["BandaEncontrada"] = true;
                TempData["NomeBanda"] = nome;
            }
            else
            {
                TempData["BandaEncontrada"] = false;
                TempData["Mensagem"] = $"A Banda '{nome}' não foi encontrada.";

            }            

            return RedirectToAction("RegistrarAlbum");
        }

        public IActionResult RegistrarAlbum()
        {
            return View(_bandasRegistradas);
        }

// depois analisar se da para fazer a verifcação dentro dos metodos, para diminuir a quantidade de codigo
        [HttpPost]
        public IActionResult SalvarAlbum(string nomeBanda, string nomeAlbum)
        {

            if (string.IsNullOrWhiteSpace(nomeAlbum))
            {
                TempData["CampoVazio"] = "Preencha o campo!";
                return RedirectToAction("RegistrarAlbum");
            }

            string nomeAlbumTrimmed = nomeAlbum.Trim();

            //analisar
            var banda = _bandasRegistradas.Bandas
                .Include(b => b.Albuns)
                .FirstOrDefault(b => b.Nome == nomeBanda);

            if (banda != null)
            {
                if (banda.Albuns.Any(a => a.Nome.Equals(nomeAlbumTrimmed, StringComparison.OrdinalIgnoreCase)))
                {
                    TempData["MesmoNome"] = "Esse Album ja foi digitado a Banda, digite outro album.";
                    return RedirectToAction("RegistrarAlbum");
                }

                banda.AdicionarAlbum(new Album(nomeAlbumTrimmed));
                _bandasRegistradas.SaveChanges();
                TempData["Confirmado"] = "Álbum registrado com sucesso para " + nomeBanda;
               
            }

            return RedirectToAction("RegistrarAlbum");
        }

        public IActionResult MostrarBandasRegistradas()
        {
            var bandas = _bandasRegistradas.Bandas.ToList();
            return View(bandas);
        }

        [HttpPost]
        public IActionResult VerificarBandaParaAvaliar(string nomeBanda)
        {
            if (string.IsNullOrWhiteSpace(nomeBanda))
            {
                TempData["CampoVazio"] = "Preencha o Campo!";
                TempData["BandaEncontrada"] = false;
                return RedirectToAction("RegistrarAlbum");
            }

            string nome = nomeBanda.Trim();

            if (BandaExiste(nome))
            {
                TempData["BandaEncontrada"] = true;
                TempData["NomeBanda"] = nome;
            }
            else
            {
                TempData["BandaEncontrada"] = false;
                TempData["Mensagem"] = $"A Banda '{nome}' não foi encontrada.";
            }

            return RedirectToAction("AvaliarUmaBanda");
        }

        public IActionResult AvaliarUmaBanda()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarNota(string nomeBanda, string nota)
        {
            if (string.IsNullOrWhiteSpace(nota))
            {
                TempData["CampoVazio"] = "Preencha o campo!";
                return RedirectToAction("AvaliarUmaBanda");
            }

            if(!double.TryParse(nota, out double notaValor))
            {
                TempData["NotaInvalida"] = "Formato invalido. Por favor, insira uma nota válida";
                return RedirectToAction("AvaliarUmaBanda");
            }

            var banda = _bandasRegistradas.Bandas
                .Include(b => b.Notas)
                .FirstOrDefault(b => b.Nome == nomeBanda);
            try
            {
                if (banda != null)
                {
                    Avaliacao novaNota = new Avaliacao { Nota = notaValor };
                    banda.AdicionarNota(novaNota);
                    _bandasRegistradas.SaveChanges();
                    TempData["Confirmado"] = $"A nota {novaNota.Nota} foi registrada com sucesso para a banda {nomeBanda}";
                }
                else
                {
                    TempData["Erro"] = "A banda não foi encontrada";
                }
            }
            catch(Exception ex)
            {
                TempData["Erro"] = $"Ocorreu um erro ao registrar a nota: {ex.Message}";
            }
            
            return RedirectToAction("AvaliarUmaBanda");
        }

        [HttpPost]
        public IActionResult VerificarBandaParaExibirDetalhes(string nomeBanda)
        {
            var viewModel = new BandaDetalhesViewModel();

            if (string.IsNullOrWhiteSpace(nomeBanda))
            {
                viewModel.Mensagem = "Preencha o Campo!";
                return View("ExibirDetalhes", viewModel);
            }

            string nome = nomeBanda.Trim();

            var banda = _bandasRegistradas.Bandas
                .Include(b => b.Albuns)
                .Include(b => b.Notas)
                .FirstOrDefault(b => b.Nome == nome);

            if (banda != null)
            {
                viewModel.BandaEncontrada = true;
                viewModel.NomeBanda = nome;
                viewModel.Media = banda.Media;
                viewModel.Discografia = banda.Albuns.Select(a => new AlbumViewModel 
                {
                    Nome = a.Nome,
                    Media = a.Media
                }).ToList();
            }
            else
            {
                viewModel.BandaEncontrada = false;
                viewModel.Mensagem = $"A Banda '{nomeBanda}' não foi encontrada.";
            }

            return View("ExibirDetalhes", viewModel);
        }

        public IActionResult ExibirDetalhes()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
