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

        public async Task<List<Lutador>> OitavasDeFinal() 
        {
            var lutadores = await _lutadorService.GetLutadoresAsync();
            var lutadoresPorIdade = lutadores.OrderBy(x => x.Idade).ToList();
            var vencedoresOitavas = new List<Lutador>();

            if (lutadores.Count < 16)
            {
                throw new InvalidOperationException("Não há lutadores suficientes para realizar as oitavas de final.");
            }

            for (int i = 0; i < 8; i++)
            {
                var lutadorMaisJovem = lutadoresPorIdade[i * 2];
                var segundoLutadorMaisJovem = lutadoresPorIdade[i * 2 + 1];
                Lutador vencedor = null;

                if (lutadorMaisJovem.Vitorias / lutadorMaisJovem.TotalLutas * 100 > segundoLutadorMaisJovem.Vitorias / segundoLutadorMaisJovem.TotalLutas * 100)
                {
                    vencedor = lutadorMaisJovem;
                }

                else if (lutadorMaisJovem.Vitorias / lutadorMaisJovem.TotalLutas * 100 < segundoLutadorMaisJovem.Vitorias / segundoLutadorMaisJovem.TotalLutas * 100)
                {
                    vencedor = segundoLutadorMaisJovem;
                }

                    vencedoresOitavas.Add(vencedor);

            }

            return  vencedoresOitavas;
        }

    }
}
