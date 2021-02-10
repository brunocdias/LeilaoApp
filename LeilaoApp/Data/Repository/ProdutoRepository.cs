using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeilaoApp.Data.Repository.IRepository;
using LeilaoApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeilaoApp.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly LeilaoContext _db;

        public ProdutoRepository(LeilaoContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetProdutoListForDropDown()
        {
            return _db.Produtos.Select(i => new SelectListItem()
            {
                Text = i.Nome,
                Value = i.Id_Produto.ToString()
            });
        }

        public void Update(Produto produto)
        {
            var objFromDb = _db.Produtos.FirstOrDefault(s => s.Id_Produto == produto.Id_Produto);

            objFromDb.Nome = produto.Nome;
            objFromDb.Valor_Inicial = produto.Valor_Inicial;

            _db.SaveChanges();
        }

    }
}