using System.Collections.Generic;
using System.Threading.Tasks;
using LeilaoApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeilaoApp.Data.Repository.IRepository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<SelectListItem> GetProdutoListForDropDown();

        void Update(Produto produto);
    }
}