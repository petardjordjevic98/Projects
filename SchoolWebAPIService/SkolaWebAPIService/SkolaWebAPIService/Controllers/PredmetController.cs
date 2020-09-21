using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkolaLibrary;
using SkolaLibrary.DTOs;



namespace SkolaWebAPIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredmetController : ControllerBase
    {
        [HttpGet]
        [Route("UcitajPredmete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPredmete()
        {
            try
            {
                return new JsonResult(DataProvider.GetPredmete());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("UcitajPredmet/{predmetID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPredmet(int predmetID)
        {
            try
            {
                return new JsonResult(DataProvider.GetPredmet(predmetID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPredmet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajPredmet([FromBody]PredmetView u)
        {
            try
            {
                DataProvider.DodajPredmet(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPredmet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzbrisiPredmet(int id)
        {
            try
            {
                DataProvider.IzbrisiPredmet(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniPredmet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniPredmet([FromBody]PredmetView u)
        {
            try
            {
                DataProvider.IzmeniPredmet(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
