using Moq;
using Torneio.Controllers;
using Torneio.Models;
using Torneio.Services;

namespace TorneioTests
{
    public class TorneioServiceTests
    {

        //private readonly ITorneioService _torneioService;

        //public TorneioServiceTests (ITorneioService torneioService) 
        //{ 
        //    _torneioService = torneioService;
        //}

        [Fact]
        public async Task OitavasDeFinal()
        {
            // Arrange

            var lutadores = new List<Lutador>
            {
                new Lutador { Id = 1, Nome = "Lutador 1", Idade = 1, ArtesMarciais = 3, TotalLutas = 100, Derrotas = 2, Vitorias = 8 },
                new Lutador { Id = 2, Nome = "Lutador 2", Idade = 16, ArtesMarciais = 4, TotalLutas = 100, Derrotas = 4, Vitorias = 8 },
                new Lutador { Id = 3, Nome = "Lutador 3", Idade = 2, ArtesMarciais = 2, TotalLutas = 100, Derrotas = 6, Vitorias = 80 },
                new Lutador { Id = 4, Nome = "Lutador 4", Idade = 15, ArtesMarciais = 5, TotalLutas = 100, Derrotas = 2, Vitorias = 60 },
                new Lutador { Id = 5, Nome = "Lutador 5", Idade = 3, ArtesMarciais = 3, TotalLutas = 100, Derrotas = 3, Vitorias = 60 },
                new Lutador { Id = 6, Nome = "Lutador 6", Idade = 14, ArtesMarciais = 4, TotalLutas = 100, Derrotas = 5, Vitorias = 60 },
                new Lutador { Id = 7, Nome = "Lutador 7", Idade = 4, ArtesMarciais = 2, TotalLutas = 100, Derrotas = 4, Vitorias = 6 },
                new Lutador { Id = 8, Nome = "Lutador 8", Idade = 13, ArtesMarciais = 5, TotalLutas = 100, Derrotas = 2, Vitorias = 5 },
                new Lutador { Id = 9, Nome = "Lutador 9", Idade = 5, ArtesMarciais = 3, TotalLutas = 100, Derrotas = 3, Vitorias = 5 },
                new Lutador { Id = 10, Nome = "Lutador 10", Idade = 12, ArtesMarciais = 4, TotalLutas = 100, Derrotas = 4, Vitorias = 5 },
                new Lutador { Id = 11, Nome = "Lutador 11", Idade = 6, ArtesMarciais = 2, TotalLutas = 100, Derrotas = 5, Vitorias = 50 },
                new Lutador { Id = 12, Nome = "Lutador 12", Idade = 11, ArtesMarciais = 5, TotalLutas = 100, Derrotas = 3, Vitorias = 40 },
                new Lutador { Id = 13, Nome = "Lutador 13", Idade = 7, ArtesMarciais = 4, TotalLutas = 100, Derrotas = 4, Vitorias = 40 },
                new Lutador { Id = 14, Nome = "Lutador 14", Idade = 10, ArtesMarciais = 3, TotalLutas = 100, Derrotas = 2, Vitorias = 40 },
                new Lutador { Id = 15, Nome = "Lutador 15", Idade = 8, ArtesMarciais = 2, TotalLutas = 100, Derrotas = 3, Vitorias = 4 },
                new Lutador { Id = 16, Nome = "Lutador 16", Idade = 9, ArtesMarciais = 5, TotalLutas = 100, Derrotas = 1, Vitorias = 4 }
            };

            var lutadorService = new Mock<ILutadorService>();
            lutadorService.Setup(s => s.GetLutadoresAsync()).ReturnsAsync(lutadores);

            var torneioService = new TorneioService(lutadorService.Object);
            // Act

            var vencedoresOitavas = torneioService.OitavasDeFinal();
            var result = vencedoresOitavas.Result;

            // Assert
            var esperado = new List<Lutador>
            {
                new Lutador { Id = 3, Nome = "Lutador 3", Idade = 2, ArtesMarciais = 2, TotalLutas = 100, Derrotas = 6, Vitorias = 80 },
                new Lutador { Id = 5, Nome = "Lutador 5", Idade = 3, ArtesMarciais = 3, TotalLutas = 100, Derrotas = 3, Vitorias = 60 },
                new Lutador { Id = 11, Nome = "Lutador 11", Idade = 6, ArtesMarciais = 2, TotalLutas = 100, Derrotas = 5, Vitorias = 50 },
                new Lutador { Id = 13, Nome = "Lutador 13", Idade = 7, ArtesMarciais = 4, TotalLutas = 100, Derrotas = 4, Vitorias = 40 },
                new Lutador { Id = 14, Nome = "Lutador 14", Idade = 10, ArtesMarciais = 3, TotalLutas = 100, Derrotas = 2, Vitorias = 40 },
                new Lutador { Id = 12, Nome = "Lutador 12", Idade = 11, ArtesMarciais = 5, TotalLutas = 100, Derrotas = 3, Vitorias = 40 },
                new Lutador { Id = 6, Nome = "Lutador 6", Idade = 14, ArtesMarciais = 4, TotalLutas = 100, Derrotas = 5, Vitorias = 60 },
                new Lutador { Id = 4, Nome = "Lutador 4", Idade = 15, ArtesMarciais = 5, TotalLutas = 100, Derrotas = 2, Vitorias = 60 }
            };

            Assert.NotNull(result);
            Assert.Equivalent(esperado, result);

            //foreach (var lutador in esperado) 
            //{
            //    Assert.Contains(result, x => x.Id == lutador.Id);
            //}
        }

    }
}