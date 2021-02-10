using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeilaoApp.Data.Repository.IRepository;
using LeilaoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeilaoApp.Data.Repository
{
    public class LanceRepository : Repository<Lance>, ILanceRepository
    {
        private readonly LeilaoContext _db;
        public LanceRepository(LeilaoContext db) : base(db)
        {
            _db = db;
        }


        public double GetValor(int id)
        {

            if (!_db.Lances.Any())
            {
                return 0;
            }

            else
                return _db.Lances.Where(r => r.Id_Produto == id).Max(x => x.Valor);


        }

        public void Update(Lance lance)
        {
            var objFromDb = _db.Lances.FirstOrDefault(s => s.Id_Lance == lance.Id_Lance);

            objFromDb.Id_Pessoa = lance.Id_Pessoa;
            objFromDb.Id_Produto = lance.Id_Produto;
            objFromDb.Valor = lance.Valor;

            _db.SaveChanges();
        }

    }
}