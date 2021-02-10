using System.Threading.Tasks;
using LeilaoApp.Data;
using LeilaoApp.Data.Repository.IRepository;
using LeilaoApp.Models;
using LeilaoApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeilaoApp.Controllers
{
    public class LancesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public LanceVM LanVM { get; set; }

        public LancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Livros
        public IActionResult List()
        {
            return View();
        }



        public IActionResult Create()
        {
            LanVM = new LanceVM()
            {
                Lances = new Models.Lance(),
                PessoaList = _unitOfWork.Pessoas.GetPessoaListForDropDown(),
                ProdutoList = _unitOfWork.Produtos.GetProdutoListForDropDown(),
            };
            return View(LanVM);
        }


        [HttpPost]
        public IActionResult Create(LanceVM lanceVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Lances.Add(LanVM.Lances);
                _unitOfWork.Save();
            }
            LanVM.PessoaList = _unitOfWork.Pessoas.GetPessoaListForDropDown();
            LanVM.ProdutoList = _unitOfWork.Produtos.GetProdutoListForDropDown();
            return RedirectToAction(nameof(List));

        }

        [HttpPost]
        public IActionResult Edit(LanceVM lanceVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Lances.Update(LanVM.Lances);
                _unitOfWork.Save();
            }
            LanVM.PessoaList = _unitOfWork.Pessoas.GetPessoaListForDropDown();
            LanVM.ProdutoList = _unitOfWork.Produtos.GetProdutoListForDropDown();
            return RedirectToAction(nameof(List));
        }

        public IActionResult Edit(int id)
        {

            LanceVM lanceVM = new LanceVM()
            {
                Lances = new Lance(),
                PessoaList = _unitOfWork.Pessoas.GetPessoaListForDropDown(),
                ProdutoList = _unitOfWork.Produtos.GetProdutoListForDropDown()
            };

            lanceVM.Lances = _unitOfWork.Lances.Get(id);

            return View(lanceVM);
        }


        #region API Calls

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Lances.GetAll(includeProperties: "Pessoas,Produtos") });
        }
        [HttpGet]
        public string GetIdade(int id)
        {

            var pessoa = _unitOfWork.Pessoas.GetFirstOrDefault(i => i.Id_Pessoa == id);

            int idade = pessoa.Idade;

            if (idade >= 18)
                return "1";
            else
                return "0";
        }

        [HttpGet]
        public double GetValor(int id)
        {

            return _unitOfWork.Lances.GetValor(id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Lances.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao deletar." });
            }

            _unitOfWork.Lances.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Excluído com sucesso." });
        }

        #endregion

    }
}