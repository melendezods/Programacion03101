using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Shedule;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly ISchedule _scheduleRepository;
        private readonly AppSettings _appSettings;

        public ScheduleController(IUtility utility, ISchedule scheduletRepository, AppSettings appSettings)
        {
            _utility = utility;
            _scheduleRepository = scheduletRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Schedule> Post([FromBody] Schedule schedule)
        {

            try
            {
                if (schedule == null) return BadRequest();
                _scheduleRepository.Create(schedule);

                return CreatedAtAction("GetSchedule", new { schedule.Id }, schedule);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Schedule> Put([FromBody] Schedule schedule)
        {

            try
            {
                if (schedule == null) return BadRequest();

                _scheduleRepository.Update(schedule);

                return Ok(schedule);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Schedule> Delete(String Id)
        {
            try
            {
                if (Id == null) return BadRequest();

                Schedule schedule = _scheduleRepository.Read(Id);


                if (schedule == null) return NoContent();

                _scheduleRepository.Delete(schedule);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{Id}", Name = "GetSchedule")]
        public ActionResult<Schedule> GetSchedule(string Id)
        {
            try
            {
                Schedule result = _scheduleRepository.Read(Id);
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

        [HttpGet(Name = "GetSchedules")]
        public ActionResult<List<Schedule>> GetSchedules()
        {
            try
            {
                List<Schedule> result = _scheduleRepository.Read();
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
