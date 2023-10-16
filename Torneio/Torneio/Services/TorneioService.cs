using MessagePack.Formatters;
using System.ComponentModel;
using Torneio.Models;

namespace Torneio.Services
{
    public class TorneioService : ITorneioService
    {
        private readonly ILutadorService _lutadorService;

        public TorneioService()
        {
        }

        public TorneioService(ILutadorService lutadorService) 
        {
            _lutadorService = lutadorService;
        }


        public async Task<double> CalcularPorcentagem(double parte , double todo) 
        {
            double porcentagem = (parte/todo) * 100;

            return porcentagem;
        }

        public async Task<Lutador> Disputa(Lutador lutador1, Lutador lutador2) // TODO atualizar vitorias e derrotas depois de cada disputa
        {
            Lutador? vencedor = null;
            double porcentagemLutador1 = await CalcularPorcentagem(lutador1.Vitorias, lutador1.TotalLutas);
            double porcentagemLutador2 = await CalcularPorcentagem(lutador2.Vitorias, lutador2.TotalLutas);

            if (porcentagemLutador1 > porcentagemLutador2)
            {
                lutador1.Vitorias++;
                lutador1.TotalLutas++;

                lutador2.Derrotas++;
                lutador2.TotalLutas++;

                vencedor = lutador1;
            }

            else if (porcentagemLutador2 > porcentagemLutador1)
            {
                lutador1.Derrotas++;
                lutador1.TotalLutas++;

                lutador2.Vitorias++;
                lutador2.TotalLutas++;

                vencedor = lutador2;
            }

            else 
            {
                if (lutador1.ArtesMarciais > lutador2.ArtesMarciais)
                {
                    lutador1.Vitorias++;
                    lutador1.TotalLutas++;

                    lutador2.Derrotas++;
                    lutador2.TotalLutas++;

                    vencedor = lutador1;
                }

                else if (lutador2.ArtesMarciais > lutador1.ArtesMarciais)
                {
                    lutador1.Derrotas++;
                    lutador1.TotalLutas++;

                    lutador2.Vitorias++;
                    lutador2.TotalLutas++;

                    vencedor = lutador2;
                }

                else 
                {
                    if (lutador1.TotalLutas > lutador2.TotalLutas)
                    {
                        lutador1.Vitorias++;
                        lutador1.TotalLutas++;

                        lutador2.Derrotas++;
                        lutador2.TotalLutas++;

                        vencedor = lutador1;
                    }

                    else if (lutador2.TotalLutas > lutador1.TotalLutas)
                    {
                        lutador1.Derrotas++;
                        lutador1.TotalLutas++;

                        lutador2.Vitorias++;
                        lutador2.TotalLutas++;

                        vencedor = lutador2;
                    }
                }
            }

            return vencedor;
        }



        public async Task<List<Lutador>> OitavasDeFinal() 
        {
            var lutadores = await _lutadorService.GetLutadoresAsync();
            var lutadoresPorIdade = lutadores.OrderBy(x => x.Idade).ToList();
            var vencedoresOitavas = new List<Lutador>();

            if (lutadores.Count < 16 || lutadores.Count > 16)
            {
                throw new InvalidOperationException("Não há lutadores suficientes para realizar as oitavas de final.");
            }

            for (int i = 0; i < 8; i++)
            {
                var lutadorMaisJovem = lutadoresPorIdade[i * 2];
                var segundoLutadorMaisJovem = lutadoresPorIdade[i * 2 + 1];

                var vencedor = await Disputa(lutadorMaisJovem,segundoLutadorMaisJovem);

                vencedoresOitavas.Add(vencedor);

            }

            return  vencedoresOitavas;
        }


        public async Task<List<Lutador>> QuartasDeFinal()
        {
            var lutadores = await OitavasDeFinal();
            var lutadoresPorIdade = lutadores.OrderBy(x => x.Idade).ToList();
            var vencedoresQuartas = new List<Lutador>();

            if (lutadores.Count < 8 || lutadores.Count > 8)
            {
                throw new InvalidOperationException("Não há lutadores suficientes para realizar as oitavas de final.");
            }

            for (int i = 0; i < 4; i++)
            {
                var lutadorMaisJovem = lutadoresPorIdade[i * 2];
                var segundoLutadorMaisJovem = lutadoresPorIdade[i * 2 + 1];

                var vencedor = await Disputa(lutadorMaisJovem,segundoLutadorMaisJovem);

                vencedoresQuartas.Add(vencedor);
            }

            return vencedoresQuartas;
        }

        public async Task<List<Lutador>> SemiFinal()
        {
            var lutadores = await QuartasDeFinal();
            var lutadoresPorIdade = lutadores.OrderBy(x => x.Idade).ToList();
            var vencedoresSemiFinais = new List<Lutador>();

            if (lutadores.Count < 4 || lutadores.Count > 4)
            {
                throw new InvalidOperationException("Não há lutadores suficientes para realizar as oitavas de final.");
            }

            for (int i = 0; i < 2; i++) 
            {
                var lutadorMaisJovem = lutadoresPorIdade[i * 2];
                var segundoLutadorMaisJovem = lutadoresPorIdade[i * 2 + 1];

                var vencedor = await Disputa(lutadorMaisJovem, segundoLutadorMaisJovem);

                vencedoresSemiFinais.Add(vencedor);
            }

            return vencedoresSemiFinais;
        }

        public async Task<Lutador> Final() // TODO Salvar campeao do torneio no banco
        {
            var lutadores = await SemiFinal();

            if (lutadores.Count < 2 || lutadores.Count > 2)
            {
                throw new InvalidOperationException("Não há lutadores suficientes para realizar as oitavas de final.");
            }

            Lutador lutador1 = lutadores[0];
            Lutador lutador2 = lutadores[1];

            var campeao = await Disputa(lutador1, lutador2);
            return campeao;
        }
    }
}
