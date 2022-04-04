using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Luggage;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuggageController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly ILuggage _luggageRepository;
        private readonly AppSettings _appSettings;

        public LuggageController(IUtility utility, ILuggage luggageRepository, AppSettings appSettings)
        {
            _utility = utility;
            _luggageRepository = luggageRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Luggage> Post([FromBody] Luggage luggage)
        {

            try
            {
                if (luggage == null) return BadRequest();
                _luggageRepository.Create(luggage);

                return CreatedAtAction("GetLuggage", new { luggage.IdLuggage }, luggage);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Luggage> Put([FromBody] Luggage luggage)
        {

            try
            {
                if (luggage == null) return BadRequest();

                _luggageRepository.Update(luggage);

                return Ok(luggage);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Luggage> Delete(String IdLuggage)
        {
            try
            {
                if (IdLuggage == null) return BadRequest();

                Luggage Luggage = _luggageRepository.Read(IdLuggage);


                if (Luggage == null) return NoContent();

                _luggageRepository.Delete(Luggage);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdLuggage}", Name = "GetLuggage")]
        public ActionResult<Luggage> GetLuggage(string IdLuggage)
        {
            try
            {
                Luggage result = _luggageRepository.Read(IdLuggage);
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

        [HttpGet(Name = "GetLuggages")]
        public ActionResult<List<Luggage>> GetLuggages()
        {
            try
            {
                List<Luggage> result = _luggageRepository.Read();
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
