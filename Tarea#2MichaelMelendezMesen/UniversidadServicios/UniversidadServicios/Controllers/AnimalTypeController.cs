using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.AnimalType;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : ControllerBase
    {

        private readonly IUtility _utility;
        private readonly IAnimalType _animalTypeRepository;
        private readonly AppSettings _appSettings;

        public AnimalTypeController(IUtility utility, IAnimalType animalTypeRepository, AppSettings appSettings)
        {
            _utility = utility;
            _animalTypeRepository = animalTypeRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<AnimalType> Post([FromBody] AnimalType animalType)
        {

            try
            {
                if (animalType == null) return BadRequest();
                _animalTypeRepository.Create(animalType);

                return CreatedAtAction("GetAnimalTyoe", new { animalType.Id }, animalType);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<AnimalType> Put([FromBody] AnimalType animalType)
        {

            try
            {
                if (animalType == null) return BadRequest();

                _animalTypeRepository.Update(animalType);

                return Ok(animalType);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<AnimalType> Delete(String Id)
        {
            try
            {
                if (Id == null) return BadRequest();

                AnimalType animalType = _animalTypeRepository.Read(Id);


                if (animalType == null) return NoContent();

                _animalTypeRepository.Delete(animalType);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{Id}", Name = "GetAnimalType")]
        public ActionResult<AnimalType> GetAnimalType(string Id)
        {
            try
            {
                AnimalType result = _animalTypeRepository.Read(Id);
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

        [HttpGet(Name = "GetAnimalTypes")]
        public ActionResult<List<AnimalType>> GetAnimalTypes()
        {
            try
            {
                List<AnimalType> result = _animalTypeRepository.Read();
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
