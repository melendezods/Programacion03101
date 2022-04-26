using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmtpController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;

        public SmtpController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;

        }

        [HttpPost]
        public void Post([FromBody] smtp smtp)
        {

            try
            {                

                _utility.SMTP.Send(smtp.Body,smtp.Subject, smtp.Email);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
