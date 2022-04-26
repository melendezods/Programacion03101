using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Flight;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly IFlight _flightRepository;
        private readonly AppSettings _appSettings;

        public FlightController(IUtility utility, IFlight flightRepository, AppSettings appSettings)
        {
            _utility = utility;
            _flightRepository = flightRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Flight> Post([FromBody] Flight flight)
        {

            try
            {
                if (flight == null) return BadRequest();
                _flightRepository.Create(flight);

                return CreatedAtAction("GetFlight", new { flight.IdFlight }, flight);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Flight> Put([FromBody] Flight flight)
        {

            try
            {
                if (flight == null) return BadRequest();

                _flightRepository.Update(flight);

                return Ok(flight);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Flight> Delete(String IdFlight)
        {
            try
            {
                if (IdFlight == null) return BadRequest();

                Flight Flight = _flightRepository.Read(IdFlight);


                if (Flight == null) return NoContent();

                _flightRepository.Delete(Flight);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdFlight}", Name = "GetFlight")]
        public ActionResult<Flight> GetFlight(string IdFlight)
        {
            try
            {
                Flight result = _flightRepository.Read(IdFlight);
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

        [HttpGet(Name = "GetFlights")]
        public ActionResult<List<Flight>> GetFlights()
        {
            try
            {
                List<Flight> result = _flightRepository.Read();
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
