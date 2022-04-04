using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Ticket;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly IUtility _utility;
        private readonly ITicket _ticketRepository;
        private readonly AppSettings _appSettings;

        public TicketController(IUtility utility, ITicket ticcketRepository, AppSettings appSettings)
        {
            _utility = utility;
            _ticketRepository = ticcketRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Ticket> Post([FromBody] Ticket ticket)
        {

            try
            {
                if (ticket == null) return BadRequest();
                _ticketRepository.Create(ticket);

                return CreatedAtAction("GetTicket", new { ticket.IdTicket }, ticket);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Ticket> Put([FromBody] Ticket ticket)
        {

            try
            {
                if (ticket == null) return BadRequest();

                _ticketRepository.Update(ticket);

                return Ok(ticket);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Ticket> Delete(String IdTicket)
        {
            try
            {
                if (IdTicket == null) return BadRequest();

                Ticket Ticket = _ticketRepository.Read(IdTicket);


                if (Ticket == null) return NoContent();

                _ticketRepository.Delete(Ticket);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdTicket}", Name = "GetTicket")]
        public ActionResult<Ticket> GetTicket(string IdTicket)
        {
            try
            {
                Ticket result = _ticketRepository.Read(IdTicket);
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

        [HttpGet(Name = "GetTickets")]
        public ActionResult<List<Ticket>> GetTickets()
        {
            try
            {
                List<Ticket> result = _ticketRepository.Read();
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
