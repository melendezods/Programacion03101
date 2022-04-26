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
    public class AirplaneController : Controller
    {

        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public AirplaneController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }

        // GET: AirplaneController
        public ActionResult Index()
        {
            List<Airplane> airplanes = JsonConvert.DeserializeObject<List<Airplane>>(_utility.RestClient.Get(_appSettings.url.Airplane));
            List<TypeAirplane> typeAirplanes =  JsonConvert.DeserializeObject<List<TypeAirplane>>(_utility.RestClient.Get(_appSettings.url.TypeAirplane));
            airplanes[0].typeAirplanes = typeAirplanes;

            return View(airplanes);
        }

        // GET: AirplaneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AirplaneController/Create
        public ActionResult Create()
        {            
            List<TypeAirplane> typeAirplanes = JsonConvert.DeserializeObject<List<TypeAirplane>>(_utility.RestClient.Get(_appSettings.url.TypeAirplane));
            Airplane airplane = new Airplane()
            {
                typeAirplanes = typeAirplanes
            }; 
            return View(airplane);
        }

        // POST: AirplaneController/Create
        [HttpPost]
        public ActionResult Create(Airplane airplane)
        {
            try
            {
                if (airplane != null)
                {
                    _utility.RestClient.Post(_appSettings.url.Airplane, JsonConvert.SerializeObject(airplane));
                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AirplaneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AirplaneController/Edit/5
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

        // GET: AirplaneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AirplaneController/Delete/5
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
