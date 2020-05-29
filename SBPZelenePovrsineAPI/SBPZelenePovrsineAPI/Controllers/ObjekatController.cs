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
    public class ObjekatController : ControllerBase
    {
        #region Objekti opste

        [HttpGet]
        [Route("PreuzmiObjekte")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetObjekti()
        {
            try
            {
                return new JsonResult(DataProvider.VratiObjekte());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiObjekte/{ParkId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetObjekti(int ParkId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiObjekteIzParka(ParkId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiObjekat/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZelenaPovrsina(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiObjekat(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiObjekat/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteObjekat(int id)
        {
            try
            {
                DataProvider.ObrisiObjekat(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Klupe

        [HttpGet]
        [Route("PreuzmiKlupe")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKlupe()
        {
            try
            {
                return new JsonResult(DataProvider.VratiKlupe());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiKlupe/{parkID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKlupe(int parkID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiKlupeIzParka(parkID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiKlupu/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKlupa(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiKlupu(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKlupuUPark/{parkID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddKlupa([FromBody]KlupaView k, int parkID)
        {
            try
            {
                DataProvider.DodajKlupuUPark(k, parkID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiKlupu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteKlupa(int id)
        {
            try
            {
                DataProvider.ObrisiKlupu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Fontane

        [HttpGet]
        [Route("PreuzmiFontane")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFontane()
        {
            try
            {
                return new JsonResult(DataProvider.VratiFontane());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiFontane/{parkID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFontane(int parkID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiFontaneIzParka(parkID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiFontanu/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFontana(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiFontanu(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajFontanuUPark/{parkID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddFontana([FromBody]FontanaView f, int parkID)
        {
            try
            {
                DataProvider.DodajFontanuUPark(f, parkID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiFontanu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteFontana(int id)
        {
            try
            {
                DataProvider.ObrisiFontanu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Svetiljke

        [HttpGet]
        [Route("PreuzmiSvetiljke")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSvetiljke()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvetiljke());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiSvetiljke/{parkID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSvetiljke(int parkID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvetiljkeIzParka(parkID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiSvetiljku/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSvetiljka(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvetiljku(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSvetiljkuUPark/{parkID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddSvetiljka([FromBody]SvetiljkaView s, int parkID)
        {
            try
            {
                DataProvider.DodajSvetiljkuUPark(s, parkID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiSvetiljku/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSvetiljka(int id)
        {
            try
            {
                DataProvider.ObrisiSvetiljku(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion
    }
}