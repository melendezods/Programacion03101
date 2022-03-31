using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Airplane;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {

        private readonly IUtility _utility;
        private readonly IAirplane _airplaneRepository;
        private readonly AppSettings _appSettings;

        public AirplaneController(IUtility utility, IAirplane airplaneRepository, AppSettings appSettings)
        {
            _utility = utility;
            _airplaneRepository = airplaneRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Airplane> Post([FromBody] Airplane airplane)
        {

            try
            {
                if (airplane == null) return BadRequest();
                _airplaneRepository.Create(airplane);

                return CreatedAtAction("GetAirplane", new { airplane.Name }, airplane);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Airplane> Put([FromBody] Airplane airplane)
        {

            try
            {
                if (airplane == null) return BadRequest();

                _airplaneRepository.Update(airplane);

                return Ok(airplane);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Airplane> Delete(String name)
        {
            try
            {
                if (name == null) return BadRequest();

                Airplane airplane = _airplaneRepository.Read(name);


                if (airplane == null) return NoContent();

                _airplaneRepository.Delete(airplane);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{name}", Name = "GetAirplane")]
        public ActionResult<Airplane> GetAirplane(string name)
        {
            try
            {
                Airplane result = _airplaneRepository.Read(name);
                if (result == null)
                    return BadRequest();                

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }
    }
}
