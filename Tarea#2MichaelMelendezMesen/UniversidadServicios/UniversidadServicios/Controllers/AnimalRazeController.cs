using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.AnimalRaze;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalRazeController : ControllerBase
    {

        private readonly IUtility _utility;
        private readonly IAnimalRaze _animalRazerRepository;
        private readonly AppSettings _appSettings;

        public AnimalRazeController(IUtility utility, IAnimalRaze animalRazeRepository, AppSettings appSettings)
        {
            _utility = utility;
            _animalRazerRepository = animalRazeRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<AnimalRaze> Post([FromBody] AnimalRaze animalRaze)
        {

            try
            {
                if (animalRaze == null) return BadRequest();
                _animalRazerRepository.Create(animalRaze);

                return CreatedAtAction("GetAnimalRaze", new { animalRaze.Id }, animalRaze);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<AnimalRaze> Put([FromBody] AnimalRaze animalRaze)
        {

            try
            {
                if (animalRaze == null) return BadRequest();

                _animalRazerRepository.Update(animalRaze);

                return Ok(animalRaze);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<AnimalRaze> Delete(String Id)
        {
            try
            {
                if (Id == null) return BadRequest();

                AnimalRaze animalRaze = _animalRazerRepository.Read(Id);


                if (animalRaze == null) return NoContent();

                _animalRazerRepository.Delete(animalRaze);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }
        [HttpGet("{Id}", Name = "GetAnimalRaze")]
        public ActionResult<AnimalRaze> GetAnimalRaze(string Id)
        {
            try
            {
                AnimalRaze result = _animalRazerRepository.Read(Id);
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
      
        [HttpGet(Name = "GetAnimalRazes")]
        public ActionResult<List<AnimalRaze>> GetAnimalRazes()
        {
            try
            {
                List<AnimalRaze> result = _animalRazerRepository.Read();
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

