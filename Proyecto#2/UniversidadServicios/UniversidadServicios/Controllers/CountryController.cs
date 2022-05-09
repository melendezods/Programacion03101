using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Country;

using UniversidadServicios.Utility;

namespace UniversidadServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUtility _utility;
        private readonly ICountry _countryRepository;
        private readonly AppSettings _appSettings;

        public CountryController(IUtility utility, ICountry countryRepository, AppSettings appSettings)
        {
            _utility = utility;
            _countryRepository = countryRepository;
            _appSettings = appSettings;

        }

        [HttpPost]
        public ActionResult<Country> Post([FromBody] Country country)
        {

            try
            {
                if (country == null) return BadRequest();
                _countryRepository.Create(country);

                return CreatedAtAction("GetCountry", new { country.IdCountry }, country);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public ActionResult<Country> Put([FromBody] Country country)
        {

            try
            {
                if (country == null) return BadRequest();

                _countryRepository.Update(country);

                return Ok(country);
            }
            catch (Exception ex)
            {

            }

            return BadRequest();

        }

        [HttpDelete]
        public ActionResult<Country> Delete(String IdCountry)
        {
            try
            {
                if (IdCountry == null) return BadRequest();

                Country country = _countryRepository.Read(IdCountry);


                if (country == null) return NoContent();

                _countryRepository.Delete(country);

                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();
        }

        [HttpGet("{IdCountry}", Name = "GetCountry")]
        public ActionResult<Country> GetCountry(string IdCountry)
        {


           

            try
            {
                Country result = _countryRepository.Read(IdCountry);
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


        [HttpGet(Name = "GetCountrys")]
        public ActionResult<List<Country>> GetCountrys()
        {
            try
            {
                List<Country> result = _countryRepository.Read();
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
