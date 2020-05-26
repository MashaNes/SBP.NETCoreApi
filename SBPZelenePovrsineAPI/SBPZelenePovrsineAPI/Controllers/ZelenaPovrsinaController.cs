using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBPZelenePovrsinePristupBazi;
using SBPZelenePovrsinePristupBazi.DTOs;

namespace SBPZelenePovrsineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZelenaPovrsinaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZelenePovrsine")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZelenePovrsine()
        {
            try
            {
                return new JsonResult(DataProvider.VratiZelenePovrsine());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiDrvorede")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDrvorede()
        {
            try
            {
                return new JsonResult(DataProvider.VratiDrvorede());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiDrvored/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDrvored(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiDrvored(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajDrvored")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddDrvored([FromBody]DrvoredView d)
        {
            try
            {
                DataProvider.SacuvajDrvored(d);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniDrvored")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeDrvored([FromBody]DrvoredView d)
        {
            try
            {
                DataProvider.IzmeniDrvored(d);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiDrvored/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteDrvored(int id)
        {
            try
            {
                DataProvider.ObrisiDrvored(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
