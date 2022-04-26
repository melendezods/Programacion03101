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
    public class AnimalRazesController : Controller
    {

        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public AnimalRazesController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }

        [HttpPost]
        public ActionResult<List<AnimalRaze>> GetAnimalRazes(int IdTypeAnimal)
        {
            try
            {
                List<AnimalRaze> result = JsonConvert.DeserializeObject<List<AnimalRaze>>(_utility.RestClient.Get(_appSettings.url.AnimalRaze)).FindAll(x => x.IdAnimalType == IdTypeAnimal).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
