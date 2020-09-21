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
    public class SmerController : ControllerBase
    {
        [HttpGet]
        [Route("UcitajSmerove")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSmerove()
        {
            try
            {
                return new JsonResult(DataProvider.GetSmerovi());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("UcitajSmer/{smerID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSmer(int smerID)
        {
            try
            {
                return new JsonResult(DataProvider.GetSmer(smerID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSmer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajSmer([FromBody]SmerView u)
        {
            try
            {
                DataProvider.DodajSmer(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiSmer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzbiriSmer(int id)
        {
            try
            {
                DataProvider.IzbrisiSmer(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniSmer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniSmer([FromBody]SmerView u)
        {
            try
            {
                DataProvider.IzmeniSmer(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
