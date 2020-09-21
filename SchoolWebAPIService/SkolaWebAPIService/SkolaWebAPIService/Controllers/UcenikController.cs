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
    public class UcenikController : ControllerBase
    {
        [HttpGet]
        [Route("UcitajUcenike")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUcenike()
        {
            try
            {
                return new JsonResult(DataProvider.GetUcenike());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("UcitajUcenika/{ucenikID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUcenika(int ucenikID)
        {
            try
            {
                return new JsonResult(DataProvider.GetUcenika(ucenikID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajUcenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajUcenika([FromBody]UcenikView u)
        {
            try
            {
                DataProvider.DodajUcenika(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiUcenika/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzbrisiUcenika(int id)
        {
            try
            {
                DataProvider.IzbrisiUcenika(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniUcenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniUcenika([FromBody]UcenikView u)
        {
            try
            {
                DataProvider.IzmeniUcenika(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
