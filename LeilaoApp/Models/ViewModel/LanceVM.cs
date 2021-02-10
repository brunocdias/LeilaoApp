using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeilaoApp.Models.ViewModel
{
    public class LanceVM
    {
        public Lance Lances { get; set; }

        public IEnumerable<SelectListItem> PessoaList { get; set; }

        public IEnumerable<SelectListItem> ProdutoList { get; set; }
    }
}