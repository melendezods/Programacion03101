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
    public class CrewController : Controller
    {

        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public CrewController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }
        // GET: CrewController
        public ActionResult Index()
        {

            List<Crew> crew = JsonConvert.DeserializeObject<List<Crew>>(_utility.RestClient.Get(_appSettings.url.Crew));
            List<CrewPerson> crewPerson = JsonConvert.DeserializeObject<List<CrewPerson>>(_utility.RestClient.Get(_appSettings.url.CrewPerson));
            List<Person> Person = JsonConvert.DeserializeObject<List<Person>>(_utility.RestClient.Get(_appSettings.url.Person));
            List<Position> position = JsonConvert.DeserializeObject<List<Position>>(_utility.RestClient.Get(_appSettings.url.Position));
            List<Gender> gender = JsonConvert.DeserializeObject<List<Gender>>(_utility.RestClient.Get(_appSettings.url.Gender));

            foreach (var item in Person)
            {
                item.position = position.First(x => x.IdPosition == item.IdPosition);
                item.gender = gender.First(x => x.IdGender == item.IdGender);
            }

            
            foreach (var item in crew)
            {
                List<Person> person = new List<Person>();
                item.crewperson = crewPerson.FindAll(x => x.IdCrew == item.IdCrew);

                foreach (var item2 in item.crewperson.FindAll(x => x.IdCrew == item.IdCrew))
                {
                    person.Add(Person.First(x => x.Identification == item2.IdPerson));
                }
                item.person = person;
            }
            

            return View(crew);
        }

        // GET: CrewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CrewController/Create
        public ActionResult Create()
        {
            List<Person> Person = JsonConvert.DeserializeObject<List<Person>>(_utility.RestClient.Get(_appSettings.url.Person));
            List<Position> position = JsonConvert.DeserializeObject<List<Position>>(_utility.RestClient.Get(_appSettings.url.Position));
            foreach (var item in Person)
            {
                item.position = position.First(x => x.IdPosition == item.IdPosition);
            }
            Person[0].Position = position;
            Crew crew = new Crew()
            {
                person = Person

            };
            return View(crew);
        }

        // POST: CrewController/Create
        [HttpPost]
        public ActionResult Create(CrewCreate crew)
        {
            try
            {
                if (crew != null)
                {
                    Crew crewSave = new Crew()
                    {
                        Description = crew.Description
                    };

                    crewSave = JsonConvert.DeserializeObject<Crew>(_utility.RestClient.Post(_appSettings.url.Crew, JsonConvert.SerializeObject(crewSave)));


                    foreach (var item in crew.CrewPerson)
                    {
                        CrewPerson crewPerson = new CrewPerson()
                        {
                            IdCrew = crewSave.IdCrew,
                            IdPerson = item
                        };
                        _utility.RestClient.Post(_appSettings.url.CrewPerson, JsonConvert.SerializeObject(crewPerson));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CrewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CrewController/Edit/5
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

        // GET: CrewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CrewController/Delete/5
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
