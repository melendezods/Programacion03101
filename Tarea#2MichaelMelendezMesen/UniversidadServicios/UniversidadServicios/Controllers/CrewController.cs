using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Crew;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : ControllerBase
    {

        private readonly IUtility _utility;
        private readonly ICrew _crewRepository;
        private readonly AppSettings _appSettings;

        public CrewController(IUtility utility, ICrew crewRepository, AppSettings appSettings)
        {
            _utility = utility;
            _crewRepository = crewRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Crew> Post([FromBody] Crew crew)
        {

            try
            {
                if (crew == null) return BadRequest();
                _crewRepository.Create(crew);

                return CreatedAtAction("GetCrew", new { crew.IdCrew }, crew);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Crew> Put([FromBody] Crew crew)
        {

            try
            {
                if (crew == null) return BadRequest();

                _crewRepository.Update(crew);

                return Ok(crew);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Crew> Delete(String IdCrew)
        {
            try
            {
                if (IdCrew == null) return BadRequest();

                Crew crew = _crewRepository.Read(IdCrew);


                if (crew == null) return NoContent();

                _crewRepository.Delete(crew);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdCrew}", Name = "GetCrew")]
        public ActionResult<Crew> GetCrew(string IdCrew)
        {
            try
            {
                Crew result = _crewRepository.Read(IdCrew);
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


        [HttpGet(Name = "GetCrews")]
        public ActionResult<List<Crew>> GetCrews()
        {
            try
            {
                List<Crew> result = _crewRepository.Read();
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
