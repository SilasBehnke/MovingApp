using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moving_App_Web_API.Controllers
{
    public class MovingAppController : Controller
    {
        // GET: MovingAppController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovingAppController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovingAppController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovingAppController/Create
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

        // GET: MovingAppController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovingAppController/Edit/5
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

        // GET: MovingAppController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovingAppController/Delete/5
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
