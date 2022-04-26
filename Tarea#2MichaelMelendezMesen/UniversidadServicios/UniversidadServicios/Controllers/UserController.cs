using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.User;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUtility _utility;
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public UserController(IUtility utility, IUserRepository userRepository, AppSettings appSettings)
        {
            _utility = utility;
            _userRepository = userRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {

            try
            {
                if (user == null) return BadRequest();
                user.Password = _utility.Encryption.Encrypt(_appSettings.SecretKey, user.Password);
                _userRepository.Create(user);

                return CreatedAtAction("GetUser", new { user.Email }, user);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Users> Put([FromBody] Users user)
        {

            try
            {
                if (user == null) return BadRequest();

                if (!_userRepository.Exist(user.Email)) return NoContent();
                user.Password = _utility.Encryption.Encrypt(_appSettings.SecretKey, user.Password);
                _userRepository.Update(user);

                return Ok(user);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Users> Delete(String email)
        {
            try
            {
                if (email == null) return BadRequest();

                Users user = _userRepository.Read(email);


                if (user == null) return NoContent();

                _userRepository.Delete(user);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();



        }

        [HttpGet("{email}", Name = "GetUser")]
        public ActionResult<Users> GetUser(string email)
        {
            try
            {
                Users result = _userRepository.Read(email);
                if (result == null)
                    return BadRequest();

                result.Password = _utility.Encryption.Decrypt(_appSettings.SecretKey, result.Password);

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
