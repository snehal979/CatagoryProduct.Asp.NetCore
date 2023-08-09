using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DataAccese.Data;
using AppModel;
using DataAccese.InfraStructure.IRespositity;
using AppModel.ViewModel;

namespace MyAppWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnityOfWork _unityofwork;
        public CategoryController(IUnityOfWork unityofwork)
        {
            _unityofwork = unityofwork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unityofwork.CategoryRespositity.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var categories = _unityofwork.CategoryRespositity.GetT(X => X.Id == id);
            return View(categories);
        }

        //Create
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category category)
        //{
        //    if (!ModelState.IsValid)//server side validation
        //    {
        //        return View(category);
        //    }
        //    _unityofwork.CategoryRespositity.Add(category);
        //    _unityofwork.Save();
        //    TempData["success"] = "Category Creaded Done!";
        //    return RedirectToAction(nameof(Index));
        //}
        [HttpGet]
        public IActionResult CreateUpdate(int id)
        {
            CategoryVM category = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(category);
            }
            else
            {
                var editcategories = _unityofwork.CategoryRespositity.GetT(X => X.Id == id);
                if (editcategories == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(editcategories);
                }
               
            }
  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(Category category, int id)
        {
            if (ModelState.IsValid)
            {

                _unityofwork.CategoryRespositity.Update(category);
                _unityofwork.Save();
                TempData["success"] = "Category Update Done!";
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categories = _unityofwork.CategoryRespositity.GetT(X => X.Id == id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int id)
        {
            var categories = _unityofwork.CategoryRespositity.GetT(X => X.Id == id);
            if (categories == null)
            {
                return NotFound();
            }
            _unityofwork.CategoryRespositity.Delete(categories);
            _unityofwork.Save();
            TempData["success"] = "Category Delete Done!";
            return RedirectToAction(nameof(Index));
        }

    }
}

