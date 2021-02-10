using System.Collections.Generic;
using System.Threading.Tasks;
using LeilaoApp.Models;

namespace LeilaoApp.Data.Repository.IRepository
{
    public interface ILanceRepository : IRepository<Lance>
    {
        public double GetValor(int id);

        void Update(Lance Lance);
    }
}