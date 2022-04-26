using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Animal;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly IAnimal _animalRepository;
        private readonly AppSettings _appSettings;

        public AnimalController(IUtility utility, IAnimal animalRepository, AppSettings appSettings)
        {
            _utility = utility;
            _animalRepository = animalRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Animal> Post([FromBody] Animal animal)
        {

            try
            {
                if (animal == null) return BadRequest();
                _animalRepository.Create(animal);

                return CreatedAtAction("GetAnimal", new { animal.Id }, animal);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Animal> Put([FromBody] Animal animal)
        {

            try
            {
                if (animal == null) return BadRequest();

                _animalRepository.Update(animal);

                return Ok(animal);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Animal> Delete(String Id)
        {
            try
            {
                if (Id == null) return BadRequest();

                Animal animal = _animalRepository.Read(Id);


                if (animal == null) return NoContent();

                _animalRepository.Delete(animal);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{Id}", Name = "GetAnimal")]
        public ActionResult<Animal> GetAnimal(string Id)
        {
            try
            {
                Animal result = _animalRepository.Read(Id);
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

        [HttpGet(Name = "GetAnimals")]
        public ActionResult<List<Animal>> GetAnimals()
        {
            try
            {
                List<Animal> result = _animalRepository.Read();
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
