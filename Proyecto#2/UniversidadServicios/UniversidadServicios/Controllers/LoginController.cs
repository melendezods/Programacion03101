using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.User;
using UniversidadServicios.Repository.Repository.User.Login;
using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository _userAuthentication;
        private readonly AppSettings _appSettings;

        public LoginController(IUtility utility, IUserRepository userRepository, AppSettings appSettings, ILoginRepository userAuthentication)
        {
            _utility = utility;
            _userRepository = userRepository;
            _appSettings = appSettings;
            _userAuthentication = userAuthentication;

        }


        [HttpPost]
        public ActionResult<Login> Post([FromBody] Users user)
        {

            try
            {
                if (user == null) return BadRequest();

                if (!_userRepository.Exist(user.Email)) return NoContent();

                Users result = _userRepository.Read(user.Email);
                if (result == null)
                    return BadRequest("El usuario no existe");

                result.Password = _utility.Encryption.Decrypt(_appSettings.SecretKey, result.Password);

                if (user.Password.Equals(result.Password))
                {
                    Guid guid = Guid.NewGuid();
                    string code = guid.ToString().Substring(1, 5);
                    result.Password = _utility.Encryption.Encrypt(_appSettings.SecretKey, result.Password);
                    UsersAuthentication userAuth = new UsersAuthentication()
                    {
                        Email = user.Email,
                        AuthDate = DateTime.Now,
                        Code = _utility.Encryption.Encrypt(_appSettings.SecretKey,code),
                        ValidMinutes = 1,
                        Status = 1
                    };
                    _userAuthentication.Create(userAuth);

                    string body = "<h1>Su código de acceso es " + code + "</h1>";

                    _utility.SMTP.Send(body, "Código de verificación", user.Email);

                    Login login = new Login()
                    {
                        Email = user.Email,
                        code = code,
                        Status = true,
                        Name = user.Name
                    };

                    return Ok(login);
                }

            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPost("VerifyCode")]
        public ActionResult<Login> VerifyCode([FromBody] Login user)
        {

            try
            {
                user.code = _utility.Encryption.Encrypt(_appSettings.SecretKey, user.code);


                if (user == null) return BadRequest();

                if (!_userRepository.Exist(user.Email)) return NoContent();

                Users result = _userRepository.Read(user.Email);
                if (result == null)
                {
                    user.Status = false;
                    user.Message = "Usuario no registrado";
                    return BadRequest(user);
                }

                bool exists = _userAuthentication.Exists(user.Email, user.code);

                if (exists)
                {
                    UsersAuthentication userAuth = _userAuthentication.Read(user.Email, user.code);

                    DateTime date = DateTime.Now;
                    TimeSpan ts = date - userAuth.AuthDate;
                    if (ts.TotalMinutes <= userAuth.ValidMinutes)
                    {

                        if (_utility.Encryption.Decrypt(_appSettings.SecretKey,user.code).Equals(_utility.Encryption.Decrypt(_appSettings.SecretKey, userAuth.Code)))
                        {
                            userAuth.Status = 0;
                            _userAuthentication.Update(userAuth);
                            user.Status = true;
                            return Ok(user);
                        }
                        else
                        {
                            user.Status = false;
                            return BadRequest(user);
                        }
                    }
                    else
                    {
                        user.Status = false;
                        userAuth.Status = 0;
                        _userAuthentication.Update(userAuth);
                        user.Message = "Tiempo expirado del código de acceso";
                        return BadRequest(user);
                    }

                }
                else
                {
                    user.Status = false;
                    user.Message = "No existe ningún código de verificación registrado para el usuario";
                    return BadRequest(user);
                }


            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }


    }
}
