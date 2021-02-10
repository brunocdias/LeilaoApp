using System.Linq;
using System.Threading.Tasks;
using LeilaoApp.Data;
using LeilaoApp.Data.Repository.IRepository;
using LeilaoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeilaoApp.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PessoasController(IUnitOfWork unitOfWork)
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

        // POST: Pessoas/Create
        [HttpPost]
        public IActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Pessoas.Add(pessoa);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Home");
            }
            return View(pessoa);
        }

        public IActionResult Edit(int id)
        {

            Pessoa pessoa = new Pessoa();
            pessoa = _unitOfWork.Pessoas.Get(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Pessoas.Update(pessoa);
                _unitOfWork.Save();

                return RedirectToAction(nameof(List));
            }
            return View(pessoa);
        }

        #region Api

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Pessoas.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Pessoas.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao deletar." });
            }

            _unitOfWork.Pessoas.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Excluído com sucesso." });
        }
        #endregion

    }
}