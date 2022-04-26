using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.AppointmentVet;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentVetController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly IAppointmentVet _appointmentVetRepository;
        private readonly AppSettings _appSettings;

        public AppointmentVetController(IUtility utility, IAppointmentVet appointmentVetRepository, AppSettings appSettings)
        {
            _utility = utility;
            _appointmentVetRepository = appointmentVetRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<AppointmentVet> Post([FromBody] AppointmentVet appointmentVet)
        {

            try
            {
                if (appointmentVet == null) return BadRequest();
                _appointmentVetRepository.Create(appointmentVet);

                return CreatedAtAction("GetAppointmentVet", new { appointmentVet.Id }, appointmentVet);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<AppointmentVet> Put([FromBody] AppointmentVet appointmentVet)
        {

            try
            {
                if (appointmentVet == null) return BadRequest();

                _appointmentVetRepository.Update(appointmentVet);

                return Ok(appointmentVet);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete("{Id}", Name = "Delete")]
        public ActionResult<AppointmentVet> Delete(int Id)
        {
            try
            {
                if (Id == null) return BadRequest();

                AppointmentVet appointmentVet = _appointmentVetRepository.Read(Id);


                if (appointmentVet == null) return NoContent();

                _appointmentVetRepository.Delete(appointmentVet);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{Id}", Name = "GetAppointmentVet")]
        public ActionResult<AppointmentVet> GetAppointmentVet(int Id)
        {
            try
            {
                AppointmentVet result = _appointmentVetRepository.Read(Id);
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

        [HttpGet(Name = "GetAppointmentVets")]
        public ActionResult<List<AppointmentVet>> GetAppointmentVets()
        {
            try
            {
                List<AppointmentVet> result = _appointmentVetRepository.Read();
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
