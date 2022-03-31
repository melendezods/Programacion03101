using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Person;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IUtility _utility;
        private readonly IPerson _personRepository;
        private readonly AppSettings _appSettings;

        public PersonController(IUtility utility, IPerson personRepository, AppSettings appSettings)
        {
            _utility = utility;
            _personRepository = personRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {

            try
            {
                if (person == null) return BadRequest();
                _personRepository.Create(person);

                return CreatedAtAction("GetPerson", new { person.Identification }, person);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Person> Put([FromBody] Person person)
        {

            try
            {
                if (person == null) return BadRequest();

                _personRepository.Update(person);

                return Ok(person);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Person> Delete(String IdPerson)
        {
            try
            {
                if (IdPerson == null) return BadRequest();

                Person Person = _personRepository.Read(IdPerson);


                if (Person == null) return NoContent();

                _personRepository.Delete(Person);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{Identification}", Name = "GetPerson")]
        public ActionResult<Person> GetPerson(string Identification)
        {
            try
            {
                Person result = _personRepository.Read(Identification);
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
