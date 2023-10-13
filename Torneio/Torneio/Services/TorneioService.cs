using MessagePack.Formatters;
using System.ComponentModel;
using Torneio.Models;

namespace Torneio.Services
{
    public class TorneioService : ITorneioService
    {
        private readonly ILutadorService _lutadorService;

        public TorneioService(ILutadorService lutadorService) 
        {
            _lutadorService = lutadorService;
        }


        public async Task<double> CalcularPorcentagem(double parte , double todo) 
        {
            double porcentagem = (parte/todo) * 100;

            return porcentagem;
        }

        public async Task<Lutador> Disputa(double porcentagemLutador1, double porcentagemLutador2) 
        {
            Lutador? vencedor = null;
            if (porcentagemLutador1 > porcentagemLutador2) { vencendor = porcentagemLutador1}
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
                Lutador? vencedor = null;
                double porcentagemLutadorJovem = await CalcularPorcentagem(lutadorMaisJovem.Vitorias, segundoLutadorMaisJovem.TotalLutas); 
                double porcentagemLutadorVelho = await CalcularPorcentagem(segundoLutadorMaisJovem.Vitorias, segundoLutadorMaisJovem.TotalLutas);


                if (porcentagemLutadorJovem > porcentagemLutadorVelho)
                {
                    vencedor = lutadorMaisJovem;
                }

                else if (porcentagemLutadorVelho > porcentagemLutadorJovem)
                {
                    vencedor = segundoLutadorMaisJovem;
                }

                    vencedoresOitavas.Add(vencedor);

            }

            return  vencedoresOitavas;
        }


        public async Task<List<Lutador>> QuartasDeFinal()
        {
            return null;
        }
    }
}
