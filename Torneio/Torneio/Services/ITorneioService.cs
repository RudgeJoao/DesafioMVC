﻿using Torneio.Models;

namespace Torneio.Services
{
    public interface ITorneioService
    {
        Task<List<Lutador>> OitavasDeFinal();

        Task<double> CalcularPorcentagem(double vitorias, double total);

        Task<Lutador> Disputa(Lutador Lutador1, Lutador Lutador2);
    }
}
