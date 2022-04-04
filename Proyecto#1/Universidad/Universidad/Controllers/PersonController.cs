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
    public class PersonController : Controller
    {
        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public PersonController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }

        // GET: PersonController
        public ActionResult Index()
        {
            List<Person> person = JsonConvert.DeserializeObject<List<Person>>(_utility.RestClient.Get(_appSettings.url.Person));
            List<Position> position = JsonConvert.DeserializeObject<List<Position>>(_utility.RestClient.Get(_appSettings.url.Position));
            List<Gender> gender = JsonConvert.DeserializeObject<List<Gender>>(_utility.RestClient.Get(_appSettings.url.Gender));

            person[0].Gender = gender;
            person[0].Position = position;

            return View(person);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            List<Position> position = JsonConvert.DeserializeObject<List<Position>>(_utility.RestClient.Get(_appSettings.url.Position));
            List<Gender> gender = JsonConvert.DeserializeObject<List<Gender>>(_utility.RestClient.Get(_appSettings.url.Gender));
            Person person = new Person()
            {
                Gender = gender,
                Position = position
            };
            return View(person);
        }

        // POST: PersonController/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {

                if (person != null)
                {
                    _utility.RestClient.Post(_appSettings.url.Person, JsonConvert.SerializeObject(person));

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
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

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
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
