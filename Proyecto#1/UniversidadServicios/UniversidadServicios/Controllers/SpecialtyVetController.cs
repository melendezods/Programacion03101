using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Speciality;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyVetController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly ISpecialtyVet _specialtyVetRepository;
        private readonly AppSettings _appSettings;

        public SpecialtyVetController(IUtility utility, ISpecialtyVet specialtyVettRepository, AppSettings appSettings)
        {
            _utility = utility;
            _specialtyVetRepository = specialtyVettRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<SpecialtyVet> Post([FromBody] SpecialtyVet SpecialtyVet)
        {

            try
            {
                if (SpecialtyVet == null) return BadRequest();
                _specialtyVetRepository.Create(SpecialtyVet);

                return CreatedAtAction("GetSpecialtyVet", new { SpecialtyVet.Id }, SpecialtyVet);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<SpecialtyVet> Put([FromBody] SpecialtyVet SpecialtyVet)
        {

            try
            {
                if (SpecialtyVet == null) return BadRequest();

                _specialtyVetRepository.Update(SpecialtyVet);

                return Ok(SpecialtyVet);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<SpecialtyVet> Delete(String Id)
        {
            try
            {
                if (Id == null) return BadRequest();

                SpecialtyVet SpecialtyVet = _specialtyVetRepository.Read(Id);


                if (SpecialtyVet == null) return NoContent();

                _specialtyVetRepository.Delete(SpecialtyVet);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{Id}", Name = "GetSpecialtyVet")]
        public ActionResult<SpecialtyVet> GetSpecialtyVet(string Id)
        {
            try
            {
                SpecialtyVet result = _specialtyVetRepository.Read(Id);
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

        [HttpGet(Name = "GetSpecialtyVets")]
        public ActionResult<List<SpecialtyVet>> GetSpecialtyVets()
        {
            try
            {
                List<SpecialtyVet> result = _specialtyVetRepository.Read();
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
