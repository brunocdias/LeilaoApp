using LeilaoApp.Data.Repository.IRepository;

namespace LeilaoApp.Data.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeilaoContext _db;

        public UnitOfWork(LeilaoContext db)
        {
            _db = db;
            Pessoas = new PessoaRepository(_db);
            Produtos = new ProdutoRepository(_db);
            Lances = new LanceRepository(_db);
        }

        public IPessoaRepository Pessoas { get; private set; }

        public IProdutoRepository Produtos { get; private set; }

        public ILanceRepository Lances { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
