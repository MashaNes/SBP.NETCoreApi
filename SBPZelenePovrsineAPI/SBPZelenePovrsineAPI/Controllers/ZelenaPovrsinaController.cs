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
        [Route("PreuzmiZelenuPovrsinu/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZelenaPovrsina(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZelenuPovrsinu(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiZelenuPovrsinu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteZelenaPovrsina(int id)
        {
            try
            {
                DataProvider.ObrisiZelenuPovrsinu(id);
                return Ok();
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

        [HttpGet]
        [Route("PreuzmiTravnjake")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTravnjaci()
        {
            try
            {
                return new JsonResult(DataProvider.VratiTravnjake());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiTravnjak/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTravnjak(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiTravnjak(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajTravnjak")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddTravnjak([FromBody]TravnjakView t)
        {
            try
            {
                DataProvider.SacuvajTravnjak(t);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniTravnjak")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeTravnjak([FromBody]TravnjakView t)
        {
            try
            {
                DataProvider.IzmeniTravnjak(t);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiTravnjak/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteTravnjak(int id)
        {
            try
            {
                DataProvider.ObrisiTravnjak(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiParkove")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetParkovi()
        {
            try
            {
                return new JsonResult(DataProvider.VratiParkove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPark/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPark(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiPark(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPark")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddPark([FromBody]ParkView p)
        {
            try
            {
                DataProvider.SacuvajPark(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPark")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePark([FromBody]ParkView p)
        {
            try
            {
                DataProvider.IzmeniPark(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPark/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePark(int id)
        {
            try
            {
                DataProvider.ObrisiPark(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
