using System;
using LeilaoApp.Data.Repository.IRepository;

namespace LeilaoApp.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPessoaRepository Pessoas { get; }

        ILanceRepository Lances { get; }

        IProdutoRepository Produtos { get; }

        void Save();
    }
}