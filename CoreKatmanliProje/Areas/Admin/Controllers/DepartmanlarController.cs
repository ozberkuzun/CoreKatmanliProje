using CoreKatmanliProjeData.Repository.IRepository;
using CoreKatmanlıProjeModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreKatmanliProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmanlarController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public DepartmanlarController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Departmanlar> departmanlist = _unitofWork.Departmanlar.GetAll();
            return View(departmanlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Departmanlar departmanlar)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Departmanlar.Add(departmanlar);
                _unitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(departmanlar);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var departmanlar = _unitofWork.Departmanlar.GetFirstOrDefault(x => x.DepartmanId == id);
            if (departmanlar == null)
            {
                return NotFound();
            }
            return View(departmanlar);
        }

        [HttpPost]
        public IActionResult Edit(Departmanlar departmanlar)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Departmanlar.Update(departmanlar);
                _unitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(departmanlar);
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var departmanlar = _unitofWork.Departmanlar.GetFirstOrDefault(x => x.DepartmanId == id);
            if (departmanlar == null)
            {
                return NotFound();
            }
            _unitofWork.Departmanlar.Remove(departmanlar);
            _unitofWork.Save();
            return RedirectToAction("Index");
        }
    }
}
