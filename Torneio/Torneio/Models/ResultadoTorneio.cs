namespace Torneio.Models
{
    public class ResultadoTorneio
    {
        public int Id { get; set; }
        public string? Vencedor { get; set; }

        public double? TaxaDeVitorias { get; set; }

        public DateTime? Data { get; set; }
    }
}
