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

        public async Task<Lutador> Disputa(Lutador Lutador1, Lutador Lutador2) 
        {
            Lutador? vencedor = null;
            double porcentagemLutador1 = await CalcularPorcentagem(Lutador1.Vitorias, Lutador1.TotalLutas);
            double porcentagemLutador2 = await CalcularPorcentagem(Lutador2.Vitorias, Lutador2.TotalLutas);

            if (porcentagemLutador1 > porcentagemLutador2)
            {
                vencedor = Lutador1;
            }

            else if (porcentagemLutador2 > porcentagemLutador1)
            {
                vencedor = Lutador2;
            }

            else 
            {
                if (Lutador1.ArtesMarciais > Lutador2.ArtesMarciais)
                {
                    vencedor = Lutador1;
                }

                else if (Lutador2.ArtesMarciais > Lutador1.ArtesMarciais)
                {
                    vencedor = Lutador2;
                }

                else 
                {
                    if (Lutador1.TotalLutas > Lutador2.TotalLutas)
                    {
                        vencedor = Lutador1;
                    }

                    else if (Lutador2.TotalLutas > Lutador1.TotalLutas)
                    {
                        vencedor = Lutador2;
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

        public async Task<Lutador> Final() 
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
