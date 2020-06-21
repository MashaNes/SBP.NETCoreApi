using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBPZelenePovrsinePristupBazi;
using SBPZelenePovrsinePristupBazi.DTOs;

namespace SBPZelenePovrsineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZasticenController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZasticeneObjekte")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZasticeniObjekti()
        {
            try
            {
                return new JsonResult(DataProvider.VratiZasticeneObjekte());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiZasticeneObjekteIzParka/{idParka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZasticeniObjektiIzParka(int idParka)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZasticeneObjekteIzParka(idParka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiZasticenObjekat/{idZastite}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZasticenObjekat(int idZastite)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZasticenObjekat(idZastite));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiZastitu/{idZastite}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteZastita(int idZastite)
        {
            try
            {
                DataProvider.ObrisiZastitu(idZastite);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZastituObjektu/{idObjekta}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult AddRadnikZelenilo([FromBody] ZasticenView zasticenView, int idObjekta)
        {
            try
            {
                DataProvider.DodajZastituObjektu(zasticenView, idObjekta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniZastitu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRadnikZelenilo([FromBody] ZasticenView zasticenView)
        {
            try
            {
                DataProvider.IzmeniZastitu(zasticenView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
