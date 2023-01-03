using CoreKatmanliProjeData.Repository.IRepository;
using CoreKatmanlıProjeModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreKatmanliProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CalisanlarController : Controller
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CalisanlarController(IUnitofWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var CalisanList = _unitOfWork.Calisanlar.GetAll();
            return View(CalisanList);
        }

        public IActionResult Crup(int? id = 0)
        {
            CalisanlarVM calisanlarVM = new()
            {
                Calisanlar = new(),
                DepartmanlarList = _unitOfWork.Departmanlar.GetAll().Select(l => new SelectListItem
                {
                    Text = l.DepartmanAd,
                    Value = l.DepartmanId.ToString()
                })
            };
            if (id == null || id <= 0)
            {
                return View(calisanlarVM);
            }
            calisanlarVM.Calisanlar = _unitOfWork.Calisanlar.GetFirstOrDefault(x => x.CalisanId == id);
            if (calisanlarVM.Calisanlar == null)
            {
                return View(calisanlarVM);
            }
            return View(calisanlarVM);
        }

        [HttpPost]
        public IActionResult Crup(CalisanlarVM calisanlarVM, IFormFile file)
        {
            string wwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwRootPath, @"img/calisanlar");
                var extension = Path.GetExtension(file.FileName);
                if (calisanlarVM.Calisanlar.Fotograf != null)
                {
                    var oldPicPath = Path.Combine(wwRootPath, calisanlarVM.Calisanlar.Fotograf);
                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension),
                    FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                calisanlarVM.Calisanlar.Fotograf = @"\img\calisanlar\" + fileName + extension;
            }
            if (calisanlarVM.Calisanlar.CalisanId <= 0)
            {
                _unitOfWork.Calisanlar.Add(calisanlarVM.Calisanlar);
            }
            else
            {
                _unitOfWork.Calisanlar.Update(calisanlarVM.Calisanlar);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var calisanlar = _unitOfWork.Calisanlar.GetFirstOrDefault(x => x.CalisanId == id);
            if (calisanlar == null)
            {
                return NotFound();
            }
            _unitOfWork.Calisanlar.Remove(calisanlar);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
