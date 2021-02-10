using System.Collections.Generic;
using System.Threading.Tasks;
using LeilaoApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeilaoApp.Data.Repository.IRepository
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        IEnumerable<SelectListItem> GetPessoaListForDropDown();

        void Update(Pessoa pessoa);
    }
}