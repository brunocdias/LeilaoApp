using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeilaoApp.Data.Repository.IRepository;
using LeilaoApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeilaoApp.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        private readonly LeilaoContext _db;

        public PessoaRepository(LeilaoContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPessoaListForDropDown()
        {
            return _db.Pessoas.Select(i => new SelectListItem()
            {
                Text = i.Nome,
                Value = i.Id_Pessoa.ToString()
            });
        }

        public void Update(Pessoa pessoa)
        {
            var objFromDb = _db.Pessoas.FirstOrDefault(s => s.Id_Pessoa == pessoa.Id_Pessoa);

            objFromDb.Nome = pessoa.Nome;
            objFromDb.Idade = pessoa.Idade;

            _db.SaveChanges();
        }
    }
}