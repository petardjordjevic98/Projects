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
    public class OcenaController : ControllerBase
    {
        [HttpGet]
        [Route("UcitajOcene")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOcene()
        {
            try
            {
                return new JsonResult(DataProvider.GetOcene());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("UcitajOcenu/{ocenaID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPredmet(int ocenaID)
        {
            try
            {
                return new JsonResult(DataProvider.GetOcena(ocenaID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajOcenu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajOcenu([FromBody]OcenaView u)
        {
            try
            {
                DataProvider.DodajOcenu(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiOcenu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzbrisiOcenu(int id)
        {
            try
            {
                DataProvider.IzbrisiOcenu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniOcenu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniOcenu([FromBody]OcenaView u)
        {
            try
            {
                DataProvider.IzmeniOcenu(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}

