using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Position;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly IPosition _positionRepository;
        private readonly AppSettings _appSettings;

        public PositionController(IUtility utility, IPosition positionRepository, AppSettings appSettings)
        {
            _utility = utility;
            _positionRepository = positionRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Position> Post([FromBody] Position position)
        {

            try
            {
                if (position == null) return BadRequest();
                _positionRepository.Create(position);

                return CreatedAtAction("GetPosition", new { position.IdPosition }, position);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Position> Put([FromBody] Position position)
        {

            try
            {
                if (position == null) return BadRequest();

                _positionRepository.Update(position);

                return Ok(position);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Position> Delete(String IdPosition)
        {
            try
            {
                if (IdPosition == null) return BadRequest();

                Position Position = _positionRepository.Read(IdPosition);


                if (Position == null) return NoContent();

                _positionRepository.Delete(Position);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdPosition}", Name = "GetPosition")]
        public ActionResult<Position> GetPosition(string IdPosition)
        {
            try
            {
                Position result = _positionRepository.Read(IdPosition);
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
