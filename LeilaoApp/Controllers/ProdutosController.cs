using LeilaoApp.Data.Repository.IRepository;
using LeilaoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeilaoApp.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProdutosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Pessoas
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public IActionResult Upsert(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (produto.Id_Produto == 0)
                {
                    _unitOfWork.Produtos.Add(produto);
                }
                else
                {
                    _unitOfWork.Produtos.Update(produto);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(List));
            }
            return View(produto);
        }

        public IActionResult Edit(int id)
        {

            Produto produto = new Produto();
            produto = _unitOfWork.Produtos.Get(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Produtos.Update(produto);
                _unitOfWork.Save();

                return RedirectToAction(nameof(List));
            }
            return View(produto);
        }

        #region Api

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Produtos.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Produtos.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao deletar." });
            }

            _unitOfWork.Produtos.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Excluído com sucesso." });
        }
        #endregion


    }
}