using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Universidad.Models;
using Universidad.Utility;

namespace Universidad.Controllers
{
    public class AppointmentVetController : Controller
    {

        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public AppointmentVetController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }
        public ActionResult Index()
        {
            List<AnimalRaze> animalRaze = JsonConvert.DeserializeObject<List<AnimalRaze>>(_utility.RestClient.Get(_appSettings.url.AnimalRaze));
            List<AnimalType> animalType = JsonConvert.DeserializeObject<List<AnimalType>>(_utility.RestClient.Get(_appSettings.url.AnimalType));
            List<Schedule> schedule = JsonConvert.DeserializeObject<List<Schedule>>(_utility.RestClient.Get(_appSettings.url.Schedule));
            List<SpecialtyVet> specialtyVet = JsonConvert.DeserializeObject<List<SpecialtyVet>>(_utility.RestClient.Get(_appSettings.url.SpecialtyVet));
            List<AppointmentVet> appointmentVets = JsonConvert.DeserializeObject<List<AppointmentVet>>(_utility.RestClient.Get(_appSettings.url.AppointmentVet));
            List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(_utility.RestClient.Get(_appSettings.url.Animal));

            if (appointmentVets.Count > 0)
            {
                appointmentVets.First().schedules = schedule;
                appointmentVets.First().animalRazes = animalRaze;
                appointmentVets.First().animalTypes = animalType;
                appointmentVets.First().specialtyVets = specialtyVet;
                appointmentVets.First().animals = animals;
            }

            return View(appointmentVets);
        }


        // GET: AppointmentVetController/Create
        public ActionResult Create()
        {
            //string user = Request.Cookies["EmailUser"];
          
            List<AnimalType> animalType = JsonConvert.DeserializeObject<List<AnimalType>>(_utility.RestClient.Get(_appSettings.url.AnimalType));
            List<SpecialtyVet> specialtyVet = JsonConvert.DeserializeObject<List<SpecialtyVet>>(_utility.RestClient.Get(_appSettings.url.SpecialtyVet));
            AppointmentVet appointment = new AppointmentVet()
            {
                specialtyVets = specialtyVet,
                animalTypes = animalType           
            };

            return View(appointment);
        }

        // POST: AppointmentVetController/Create
        [HttpPost]
        public ActionResult Create(AppointmentVet appointment)
        {
            try
            {
                string IdUser = Request.Cookies["EmailUser"];
                if (appointment != null)
                {
                   User user = JsonConvert.DeserializeObject<User>(_utility.RestClient.Get(_appSettings.url.GetUser + IdUser));
                    appointment.Name = "Cita veterinaria " + user.Name + " " + user.LastName + " " + appointment.NameAnimal;
                    Animal animal = new Animal()
                    {
                        Name = appointment.NameAnimal,
                        Description = appointment.DescriptionAnimal,
                        Age = appointment.AgeAnimal,
                        IdAnimalRaze = appointment.IdAnimalRaze,
                        IdAnimalType = appointment.IdAnimalType
                    };

                    Animal animalResult = JsonConvert.DeserializeObject<Animal>(_utility.RestClient.Post(_appSettings.url.Animal, JsonConvert.SerializeObject(animal)));
                    appointment.IdAnimal = animalResult.Id;
                    appointment.IdUser = IdUser;
                    _utility.RestClient.Post(_appSettings.url.AppointmentVet, JsonConvert.SerializeObject(appointment));


                    Smtp smtp = new Smtp()
                    {
                        Body = "<div><h1>"+ appointment.Name + "</h1> <p>Confirmación de su cita veterinara para el día "+ appointment.date +" para su mascota "+animal.Name+"</p><h2>Lo esperamos, será un gusto atenderlo</h2></div>",
                        Subject = appointment.Name,
                        Email = IdUser

                    };

                    _utility.RestClient.Post(_appSettings.url.Smtp, JsonConvert.SerializeObject(smtp));

                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Editar(string id)
        {
            try
            {                

                List<AnimalRaze> animalRaze = JsonConvert.DeserializeObject<List<AnimalRaze>>(_utility.RestClient.Get(_appSettings.url.AnimalRaze));
                List<AnimalType> animalType = JsonConvert.DeserializeObject<List<AnimalType>>(_utility.RestClient.Get(_appSettings.url.AnimalType));
                List<Schedule> schedule = JsonConvert.DeserializeObject<List<Schedule>>(_utility.RestClient.Get(_appSettings.url.Schedule));
                List<SpecialtyVet> specialtyVet = JsonConvert.DeserializeObject<List<SpecialtyVet>>(_utility.RestClient.Get(_appSettings.url.SpecialtyVet));
                List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(_utility.RestClient.Get(_appSettings.url.Animal));
                AppointmentVet appointment = JsonConvert.DeserializeObject<AppointmentVet>(_utility.RestClient.Get(_appSettings.url.AppointmentVet + id));

                appointment.schedules = schedule;
                appointment.animalRazes = animalRaze;
                appointment.animalTypes = animalType;
                appointment.specialtyVets = specialtyVet;
                appointment.animals = animals;

                return View(appointment);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Editar(AppointmentVet appointment)
        {
            try
            {
                string IdUser = Request.Cookies["EmailUser"];
                if (appointment != null)
                {

                    _utility.RestClient.Delete(_appSettings.url.AppointmentVet + appointment.Id);

                    User user = JsonConvert.DeserializeObject<User>(_utility.RestClient.Get(_appSettings.url.GetUser + IdUser));
                    appointment.Name = "Cita veterinaria " + user.Name + " " + user.LastName + " " + appointment.NameAnimal;
                    Animal animal = new Animal()
                    {
                        Name = appointment.NameAnimal,
                        Description = appointment.DescriptionAnimal,
                        Age = appointment.AgeAnimal,
                        IdAnimalRaze = appointment.IdAnimalRaze,
                        IdAnimalType = appointment.IdAnimalType
                    };

                    Animal animalResult = JsonConvert.DeserializeObject<Animal>(_utility.RestClient.Post(_appSettings.url.Animal, JsonConvert.SerializeObject(animal)));
                    appointment.IdAnimal = animalResult.Id;
                    appointment.IdUser = IdUser;
                    appointment.Id = 0;
                    _utility.RestClient.Post(_appSettings.url.AppointmentVet, JsonConvert.SerializeObject(appointment));


                    Smtp smtp = new Smtp()
                    {
                        Body = "<div><h1>" + appointment.Name + "</h1> <p>Actualización de su cita veterinara para el día " + appointment.date + " para su mascota " + animal.Name + "</p><h2>Lo esperamos, será un gusto atenderlo</h2></div>",
                        Subject = appointment.Name,
                        Email = IdUser

                    };

                    _utility.RestClient.Post(_appSettings.url.Smtp, JsonConvert.SerializeObject(smtp));

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}
