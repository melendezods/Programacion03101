using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.TypeAirplane;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeAirplaneController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly ITypeAirplane _typeAirplaneRepository;
        private readonly AppSettings _appSettings;

        public TypeAirplaneController(IUtility utility, ITypeAirplane typeAirplaneRepository, AppSettings appSettings)
        {
            _utility = utility;
            _typeAirplaneRepository = typeAirplaneRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<TypeAirplane> Post([FromBody] TypeAirplane typeAirplane)
        {

            try
            {
                if (typeAirplane == null) return BadRequest();
                _typeAirplaneRepository.Create(typeAirplane);

                return CreatedAtAction("GetTypeAirplane", new { typeAirplane.IdTypeAirplane }, typeAirplane);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<TypeAirplane> Put([FromBody] TypeAirplane typeAirplane)
        {

            try
            {
                if (typeAirplane == null) return BadRequest();

                _typeAirplaneRepository.Update(typeAirplane);

                return Ok(typeAirplane);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<TypeAirplane> Delete(String IdTypeAirplane)
        {
            try
            {
                if (IdTypeAirplane == null) return BadRequest();

                TypeAirplane TypeAirplane = _typeAirplaneRepository.Read(IdTypeAirplane);


                if (TypeAirplane == null) return NoContent();

                _typeAirplaneRepository.Delete(TypeAirplane);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdTypeAirplane}", Name = "GetTypeAirplane")]
        public ActionResult<TypeAirplane> GetTypeAirplane(string IdTypeAirplane)
        {
            try
            {
                TypeAirplane result = _typeAirplaneRepository.Read(IdTypeAirplane);
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
