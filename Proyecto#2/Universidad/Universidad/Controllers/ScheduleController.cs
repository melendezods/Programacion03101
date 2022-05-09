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
    public class ScheduleController : Controller
    {
        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;


        public ScheduleController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }

        [HttpPost]
        public ActionResult<List<Schedule>> GetSchedule(int IdSpecialty, string date)
        {
            try
            {
                List<Schedule> result = JsonConvert.DeserializeObject<List<Schedule>>(_utility.RestClient.Get(_appSettings.url.Schedule)).FindAll(x => x.IdSpecialty == IdSpecialty && x.AppointmentDate.ToString("yyyy-MM-dd") == date).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
