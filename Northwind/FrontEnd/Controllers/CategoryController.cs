using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CategoryController : Controller
    {
        CategoryHelper categoryHelper;

        // GET: CategoryController
        public ActionResult Index()
        {
            categoryHelper = new CategoryHelper();
            List<CategoryViewModel> list = categoryHelper.GetAll();

            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            categoryHelper = new CategoryHelper();
            CategoryViewModel category = categoryHelper.GetByID(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel category)
        {
            try
            {
                categoryHelper = new CategoryHelper();
                category = categoryHelper.Add(category);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            categoryHelper = new CategoryHelper();
            CategoryViewModel category = categoryHelper.GetByID(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            try
            {
                categoryHelper = new CategoryHelper();
                category = categoryHelper.Edit(category);
               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {

            categoryHelper = new CategoryHelper();
            CategoryViewModel category = categoryHelper.GetByID(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel category)
        {
            try
            {

                categoryHelper = new CategoryHelper();
                categoryHelper.Delete(category.CategoryId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult UploadImage(int id)
        {
            categoryHelper = new CategoryHelper();
            CategoryViewModel category = categoryHelper.GetByID(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult UploadImage(CategoryViewModel category, List<IFormFile> files)
        {

            if (files.Count>0)
            {
                IFormFile formFile = files[0];

                using (var ms= new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    category.Picture = ms.ToArray();
                }


            }


            categoryHelper = new CategoryHelper();
            CategoryViewModel cat = categoryHelper.GetByID(category.CategoryId);
            cat.Picture=category.Picture;

            categoryHelper.Edit(cat);


            return RedirectToAction("Details", new {id = cat.CategoryId});
        }

    }
}
