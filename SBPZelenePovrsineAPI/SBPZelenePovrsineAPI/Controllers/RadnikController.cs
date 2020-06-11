using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Engine;
using SBPZelenePovrsinePristupBazi;
using SBPZelenePovrsinePristupBazi.DTOs;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadnikController : ControllerBase
    {

        #region RadniciOpste

        [HttpGet]
        [Route("PreuzmiRadnike")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadnici()
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadnike());
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region RadniciOdzavanjeZelenila

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

        public IActionResult AddRadnikZelenilo([FromBody] RadnikOdrzavanjeZelenilaView radnikView)
        {
            try
            {
                DataProvider.SacuvajRadnikaOdrzavanjeZelenila(radnikView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniRadnikaOdrzavanjeZelenila")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRadnikZelenilo([FromBody] RadnikOdrzavanjeZelenilaView radnikView)
        {
            try
            {
                DataProvider.IzmeniRadnikaOdrzavanjeZelenila(radnikView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiRadnikaOdrzavanjeZelenila/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteRadnikZelenilo(string brKnjizice)
        {
            try
            {
                DataProvider.ObrisiRadnikaOdrzavanjeZelenila(brKnjizice);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region RadniciOdrzavanjeHigijene

        [HttpGet]
        [Route("PreuzmiRadnikeOdrzavanjeHigijene")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadniciHigijena()
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadnikeOdrzavanjeHigijene());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRadnikaOdrzavanjeHigijene/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadnikHigijena(string brKnjizice)
        {
            try
            {
                return new JsonResult(DataProvider.VratiOdredjenogRadnikaOdrzavanjeHigijene(brKnjizice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRadnikaOdrzavanjeHigijene")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddRadnikHigijena([FromBody] RadnikOdrzavanjeHigijeneView radnikView)
        {
            try
            {
                DataProvider.SacuvajRadnikaOdrzavanjeHigijene(radnikView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniRadnikaOdrzavanjeHigijene")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRadnikHigijena([FromBody] RadnikOdrzavanjeHigijeneView radnikView)
        {
            try
            {
                DataProvider.IzmeniRadnikaOdrzavanjeHigijene(radnikView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiRadnikaOdrzavanjeHigijene/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteRadnikHigijena(string brKnjizice)
        {
            try
            {
                DataProvider.ObrisiRadnikaOdrzavanjeHigijene(brKnjizice);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region RadniciOdrzavanjeObjekata

        [HttpGet]
        [Route("PreuzmiRadnikeOdrzavanjeObjekata")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadniciOdrzavanjeObjekata()
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadnikeOdrzavanjeObjekata());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRadnikaOdrzavanjeObjekata/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadnikOdrzavanjeObjekata(string brKnjizice)
        {
            try
            {
                return new JsonResult(DataProvider.VratiOdredjenogRadnikaOdrzavanjeObjekata(brKnjizice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRadnikaOdrzavanjeObjekata/{idParka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddRadnikOdrzavanjeObjekata([FromBody] RadiUView radiUView, int idParka)
        {
            try
            {
                ParkView park = DataProvider.VratiPark(idParka);
                radiUView.Park = park;
                DataProvider.DodajRadnikaOdrzavanjeObjekata(radiUView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniRadnikaOdrzavanjeObjekata")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRadnikOdrzavanjeObjekata([FromBody] RadnikOdrzavanjeObjekataUParkuView radnikView)
        {
            try
            {
                DataProvider.IzmeniRadnikaOdrzavanjeObjekata(radnikView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiRadnikaOdrzavanjeObjekata/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteRadnikOdrzavanjeObjekata(string brKnjizice)
        {
            try
            {
                DataProvider.ObrisiRadnikaOdrzavanjeObjekata(brKnjizice);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region RadniOdnosi

        [HttpGet]
        [Route("PreuzmiRadneOdnose")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadniOdnosi()
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadneOdnose());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRadniOdnos/{radiUId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadniOdnos(int radiUId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadniOdnos(radiUId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRadneOdnoseRadnika/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadniOdnosiRadnika(string brKnjizice)
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadneOdnoseRadnika(brKnjizice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRadneOdnoseIzParka/{idParka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRadniOdnosiIzParka(int idParka)
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadneOdnoseIzParka(idParka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRadniOdnos/{brKnjizice}/{idParka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddRadniOdnos([FromBody] RadiUView radiUView, string brKnjizice, int idParka)
        {
            try
            {
                DataProvider.DodajRadniOdnos(radiUView, brKnjizice, idParka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniRadniOdnos")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRadniOdnos([FromBody] RadiUView radiUView)
        {
            try
            {
                DataProvider.IzmeniRadniOdnos(radiUView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiRadniOdnos/{radiUId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteRadniOdnos(int radiUId)
        {
            try
            {
                DataProvider.IzbrisiRadniOdnos(radiUId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Sefovanja

        [HttpGet]
        [Route("PreuzmiSefovanja")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSefovanja()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSefovanja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiSefovanje/{jeSefId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSefovanje(int jeSefId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSefovanje(jeSefId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiSefovanjaRadnika/{brKnjizice}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSefovanjaRadnika(string brKnjizice)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSefovanjaRadnika(brKnjizice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiSefovanjaIzParka/{idParka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSefovanjaIzParka(int idParka)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSefovanjaIzParka(idParka));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSefovanje/{brKnjizice}/{idParka}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddSefovanje([FromBody] JeSefView jeSefView, string brKnjizice, int idParka)
        {
            try
            {
                DataProvider.DodajSefovanje(jeSefView, brKnjizice, idParka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSefovanje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeSefovanje([FromBody] JeSefView jeSefView)
        {
            try
            {
                DataProvider.IzmeniSefovanje(jeSefView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiSefovanje/{jeSefId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteSefovanje(int jeSefId)
        {
            try
            {
                DataProvider.IzbrisiSefovanje(jeSefId);
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
