using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using Torneio.Controllers;
using Torneio.Models;
using Torneio.Repositories;
using Torneio.Services;

namespace TorneioTests
{
    public class TorneioServiceTests
    {

        //public ITorneioService _torneioService;

        //public TorneioServiceTests(ITorneioService torneioService)
        //{

        //    var torneioServiceMock = new Mock<ITorneioService>();

        //    _torneioService = torneioServiceMock.Object;
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

            var mock = new Mock<ITorneioRepository>();
            mock.Setup(s => s.ListarLutadoresAsync()).ReturnsAsync(lutadores);

            var torneioService = new TorneioService(mock.Object);
            // Act

            var vencedoresOitavas = torneioService.OitavasDeFinal();
            var result = vencedoresOitavas.Result;

            // Assert
            var esperado = new List<Lutador>
            {
                new Lutador { Id = 3, Nome = "Lutador 3", Idade = 2, ArtesMarciais = 2, TotalLutas = 101, Derrotas = 6, Vitorias = 81 },
                new Lutador { Id = 5, Nome = "Lutador 5", Idade = 3, ArtesMarciais = 3, TotalLutas = 101, Derrotas = 3, Vitorias = 61 },
                new Lutador { Id = 11, Nome = "Lutador 11", Idade = 6, ArtesMarciais = 2, TotalLutas = 101, Derrotas = 5, Vitorias = 51 },
                new Lutador { Id = 13, Nome = "Lutador 13", Idade = 7, ArtesMarciais = 4, TotalLutas = 101, Derrotas = 4, Vitorias = 41 },
                new Lutador { Id = 14, Nome = "Lutador 14", Idade = 10, ArtesMarciais = 3, TotalLutas = 101, Derrotas = 2, Vitorias = 41 },
                new Lutador { Id = 12, Nome = "Lutador 12", Idade = 11, ArtesMarciais = 5, TotalLutas = 101, Derrotas = 3, Vitorias = 41 },
                new Lutador { Id = 6, Nome = "Lutador 6", Idade = 14, ArtesMarciais = 4, TotalLutas = 101, Derrotas = 5, Vitorias = 61 },
                new Lutador { Id = 4, Nome = "Lutador 4", Idade = 15, ArtesMarciais = 5, TotalLutas = 101, Derrotas = 2, Vitorias = 61 }
            };

            Assert.NotNull(result);
            Assert.Equivalent(esperado, result);

            //foreach (var lutador in esperado) 
            //{
            //    Assert.Contains(result, x => x.Id == lutador.Id);
            //}
        }
        [Fact]
        public async Task QuartasDeFinal() 
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

            var mock = new Mock<ITorneioRepository>();
            mock.Setup(s => s.ListarLutadoresAsync()).ReturnsAsync(lutadores);

            var torneioService = new TorneioService(mock.Object);

            // Act
            var vencedoresQuartas = torneioService.QuartasDeFinal();
            var result = vencedoresQuartas.Result;
            // Assert


            var esperado = new List<Lutador>
            {
                new Lutador { Id = 3, Nome = "Lutador 3", Idade = 2, ArtesMarciais = 2, TotalLutas = 102, Derrotas = 6, Vitorias = 82 },
                new Lutador { Id = 11, Nome = "Lutador 11", Idade = 6, ArtesMarciais = 2, TotalLutas = 102, Derrotas = 5, Vitorias = 52 },
                new Lutador { Id = 12, Nome = "Lutador 12", Idade = 11, ArtesMarciais = 5, TotalLutas = 102, Derrotas = 3, Vitorias = 42 },
                new Lutador { Id = 4, Nome = "Lutador 4", Idade = 15, ArtesMarciais = 5, TotalLutas = 102, Derrotas = 2, Vitorias = 62 }
            };
            Assert.Equal(4,result.Count);
            Assert.Equivalent(esperado, result);
        }

        [Fact]
        public async Task SemiFinal()
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

            var mock = new Mock<ITorneioRepository>();
            mock.Setup(s => s.ListarLutadoresAsync()).ReturnsAsync(lutadores);

            var torneioService = new TorneioService(mock.Object);

            // Act
            var finalistas = torneioService.SemiFinal();
            var result = finalistas.Result;
            // Assert


            var esperado = new List<Lutador>
            {
                new Lutador { Id = 3, Nome = "Lutador 3", Idade = 2, ArtesMarciais = 2, TotalLutas = 103, Derrotas = 6, Vitorias = 83 },
                new Lutador { Id = 4, Nome = "Lutador 4", Idade = 15, ArtesMarciais = 5, TotalLutas = 103, Derrotas = 2, Vitorias = 63 }
            };
            Assert.Equivalent(esperado, result);
        }

        [Fact]
        public async Task Final()
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

            var mock = new Mock<ITorneioRepository>();
            mock.Setup(s => s.ListarLutadoresAsync()).ReturnsAsync(lutadores);

            var torneioService = new TorneioService(mock.Object);

            // Act
            var campeao = torneioService.Final();
            var result = campeao.Result;
            // Assert


            var esperado = new Lutador { Id = 3, Nome = "Lutador 3", Idade = 2, ArtesMarciais = 2, TotalLutas = 104, Derrotas = 6, Vitorias = 84 };
            Assert.Equivalent(esperado, result);
        }

        [Fact]
        public async Task Porcentagem()
        {
            // Arrange
            double parte = 125;
            double todo = 250;

            // Act
            var torneioService = new TorneioService();

            var porcentagem = await torneioService.CalcularPorcentagem(parte, todo);
            // Assert

            Assert.Equal(50, porcentagem);

        }

        [Fact]
        public async Task Disputa()
        {

            // Arrange
            Lutador lutador1 = new Lutador { Id = 1, Nome = "Lutador 1", Idade = 1, ArtesMarciais = 3, TotalLutas = 100, Derrotas = 2, Vitorias = 8 };
            Lutador lutador2 = new Lutador { Id = 3, Nome = "Lutador 3", Idade = 2, ArtesMarciais = 2, TotalLutas = 100, Derrotas = 6, Vitorias = 80 };

            // Act
            var torneioService = new TorneioService();

            var disputa = await torneioService.Disputa(lutador1, lutador2);

            //Assert

            Assert.Equal(lutador2, disputa);
        }
    }
}