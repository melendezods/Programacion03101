using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Universidad.Controllers
{
    public class TypeAirplaneController : Controller
    {
        // GET: TypeAirplaneController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TypeAirplaneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypeAirplaneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeAirplaneController/Create
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

        // GET: TypeAirplaneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TypeAirplaneController/Edit/5
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

        // GET: TypeAirplaneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeAirplaneController/Delete/5
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
