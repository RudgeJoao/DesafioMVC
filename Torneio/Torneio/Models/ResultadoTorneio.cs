namespace Torneio.Models
{
    public class ResultadoTorneio
    {
        public int Id { get; set; }
        public Lutador Vencedor { get; set; }

        public DateTime? Data { get; set; }
    }
}
