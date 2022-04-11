using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chemical_Management.Controllers
{
    public class AssayController : Controller
    {
        // GET: AssayController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AssayController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssayController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssayController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
