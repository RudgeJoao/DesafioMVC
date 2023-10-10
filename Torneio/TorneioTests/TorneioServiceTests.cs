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
        public async Task OitavasDeFinalRetornaOito()
        {
            // Arrange

            var lutadores = new List<Lutador>
            {
                new Lutador { Id = 1, Nome = "Lutador 1", Idade = 25, ArtesMarciais = 3, TotalLutas = 10, Derrotas = 2, Vitorias = 8 },
                new Lutador { Id = 2, Nome = "Lutador 2", Idade = 28, ArtesMarciais = 4, TotalLutas = 12, Derrotas = 4, Vitorias = 8 },
                new Lutador { Id = 3, Nome = "Lutador 3", Idade = 30, ArtesMarciais = 2, TotalLutas = 14, Derrotas = 6, Vitorias = 8 },
                new Lutador { Id = 4, Nome = "Lutador 4", Idade = 22, ArtesMarciais = 5, TotalLutas = 8, Derrotas = 2, Vitorias = 6 },
                new Lutador { Id = 5, Nome = "Lutador 5", Idade = 26, ArtesMarciais = 3, TotalLutas = 9, Derrotas = 3, Vitorias = 6 },
                new Lutador { Id = 6, Nome = "Lutador 6", Idade = 29, ArtesMarciais = 4, TotalLutas = 11, Derrotas = 5, Vitorias = 6 },
                new Lutador { Id = 7, Nome = "Lutador 7", Idade = 27, ArtesMarciais = 2, TotalLutas = 10, Derrotas = 4, Vitorias = 6 },
                new Lutador { Id = 8, Nome = "Lutador 8", Idade = 24, ArtesMarciais = 5, TotalLutas = 7, Derrotas = 2, Vitorias = 5 },
                new Lutador { Id = 9, Nome = "Lutador 9", Idade = 31, ArtesMarciais = 3, TotalLutas = 8, Derrotas = 3, Vitorias = 5 },
                new Lutador { Id = 10, Nome = "Lutador 10", Idade = 23, ArtesMarciais = 4, TotalLutas = 9, Derrotas = 4, Vitorias = 5 },
                new Lutador { Id = 11, Nome = "Lutador 11", Idade = 32, ArtesMarciais = 2, TotalLutas = 10, Derrotas = 5, Vitorias = 5 },
                new Lutador { Id = 12, Nome = "Lutador 12", Idade = 33, ArtesMarciais = 5, TotalLutas = 7, Derrotas = 3, Vitorias = 4 },
                new Lutador { Id = 13, Nome = "Lutador 13", Idade = 34, ArtesMarciais = 4, TotalLutas = 8, Derrotas = 4, Vitorias = 4 },
                new Lutador { Id = 14, Nome = "Lutador 14", Idade = 35, ArtesMarciais = 3, TotalLutas = 6, Derrotas = 2, Vitorias = 4 },
                new Lutador { Id = 15, Nome = "Lutador 15", Idade = 36, ArtesMarciais = 2, TotalLutas = 7, Derrotas = 3, Vitorias = 4 },
                new Lutador { Id = 16, Nome = "Lutador 16", Idade = 37, ArtesMarciais = 5, TotalLutas = 5, Derrotas = 1, Vitorias = 4 }
            };

            var lutadorService = new Mock<ILutadorService>();
            lutadorService.Setup(s => s.GetLutadoresAsync()).ReturnsAsync(lutadores);

            var torneioService = new TorneioService(lutadorService.Object);
            // Act

            var vencedoresOitavas = torneioService.OitavasDeFinal();
            var result = vencedoresOitavas.Result;

            // Assert
            int quantidadeEsperada = 8; //Oitavas de final, de 16 sobram 8
            Assert.NotNull(result);
            Assert.Equal(quantidadeEsperada, result.Count);
        }

    }
}