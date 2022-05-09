using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Universidad.Models;
using Universidad.Utility;

namespace Universidad.Controllers
{
    public class LuggageController : Controller
    {


        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public LuggageController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }
        // GET: LuggageController
        public ActionResult Index()
        {
            List<Luggage> luggage = JsonConvert.DeserializeObject<List<Luggage>>(_utility.RestClient.Get(_appSettings.url.Luggage));
            return View(luggage);
        }

        // GET: LuggageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LuggageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LuggageController/Create
        [HttpPost]
        public ActionResult Create(Luggage luggage)
        {
            try
            {

                if (luggage != null)
                {
                    _utility.RestClient.Post(_appSettings.url.Luggage, JsonConvert.SerializeObject(luggage));

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LuggageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LuggageController/Edit/5
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

        // GET: LuggageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LuggageController/Delete/5
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
