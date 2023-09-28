﻿using Torneio.Models;

namespace Torneio.Services
{
    public interface ITorneioService
    {
        Task<List<Lutador>> ListarLutadoresAsync();

        Task<Lutador> GetLutadorAsync(int? id);
    }
}
