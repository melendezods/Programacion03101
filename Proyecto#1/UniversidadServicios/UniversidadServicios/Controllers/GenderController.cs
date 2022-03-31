using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Gender;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly IGender _genderRepository;
        private readonly AppSettings _appSettings;

        public GenderController(IUtility utility, IGender genderRepository, AppSettings appSettings)
        {
            _utility = utility;
            _genderRepository = genderRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Gender> Post([FromBody] Gender gender)
        {

            try
            {
                if (gender == null) return BadRequest();
                _genderRepository.Create(gender);

                return CreatedAtAction("GetGender", new { gender.IdGender }, gender);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Gender> Put([FromBody] Gender gender)
        {

            try
            {
                if (gender == null) return BadRequest();

                _genderRepository.Update(gender);

                return Ok(gender);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Gender> Delete(String IdGender)
        {
            try
            {
                if (IdGender == null) return BadRequest();

                Gender gender = _genderRepository.Read(IdGender);


                if (gender == null) return NoContent();

                _genderRepository.Delete(gender);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdGender}", Name = "GetGender")]
        public ActionResult<Gender> GetGender(string IdGender)
        {
            try
            {
                Gender result = _genderRepository.Read(IdGender);
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
