using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Engine;
using SBPZelenePovrsinePristupBazi;
using SBPZelenePovrsinePristupBazi.DTOs;

namespace SBPZelenePovrsineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadnikController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiRadnike")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadnici()
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadnike());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRadnika/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadnik(string brKnjizice)
        {
            try
            {
                return new JsonResult(DataProvider.VratiOdredjenogRadnika(brKnjizice));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiRadnika/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteRadnik(string brKnjizice)
        {
            try
            {
                DataProvider.ObrisiRadnika(brKnjizice);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRadnikeOdrzavanjeZelenila")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadniciZelenilo()
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadnikeOdrzavanjeZelenila());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRadnikaOdrzavanjeZelenila/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadnikZelenilo(string brKnjizice)
        {
            try
            {
                return new JsonResult(DataProvider.VratiOdredjenogRadnikaOdrzavanjeZelenila(brKnjizice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRadnikaOdrzavanjeZelenila")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Post([FromBody]RadnikOdrzavanjeZelenilaView radnikView)
        {
            try
            {
                DataProvider.SacuvajRadnikaOdrzavanjeZelenila(radnikView);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniRadnikaOdrzavanjeZelenila")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Put([FromBody]RadnikOdrzavanjeZelenilaView radnikView)
        {
            try
            { 
                DataProvider.IzmeniRadnikaOdrzavanjeZelenila(radnikView);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
