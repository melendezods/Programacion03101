using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.CrewPerson;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewPersonController : ControllerBase
    {

        private readonly IUtility _utility;
        private readonly ICrewPerson _crewRepository;
        private readonly AppSettings _appSettings;

        public CrewPersonController(IUtility utility, ICrewPerson crewRepository, AppSettings appSettings)
        {
            _utility = utility;
            _crewRepository = crewRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Crewperson> Post([FromBody] Crewperson crewPerson)
        {

            try
            {
                if (crewPerson == null) return BadRequest();
                _crewRepository.Create(crewPerson);

                return CreatedAtAction("GetCrewPerson", new { crewPerson.IdCrew, crewPerson.IdPerson }, crewPerson);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Crewperson> Put([FromBody] Crewperson CrewPerson)
        {

            try
            {
                if (CrewPerson == null) return BadRequest();

                _crewRepository.Update(CrewPerson);

                return Ok(CrewPerson);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Crewperson> Delete(string IdPerson, string IdCrew)
        {
            try
            {
                if (IdPerson == null || IdCrew == null) return BadRequest();

                Crewperson CrewPerson = _crewRepository.Read(IdPerson, IdCrew);


                if (CrewPerson == null) return NoContent();

                _crewRepository.Delete(CrewPerson);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdCrew,IdPerson}", Name = "GetCrewPerson")]
        public ActionResult<Crewperson> GetCrewPerson(string IdCrew, string IdPerson)
        {
            try
            {
                Crewperson result = _crewRepository.Read(IdCrew, IdPerson);
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
