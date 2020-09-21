using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkolaLibrary;
using SkolaLibrary.DTOs;
using SkolaLibrary.Entiteti;

namespace SkolaWebAPIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZaposleniController : ControllerBase
    {
        [HttpGet]
        [Route("UcitajNastavnoPN")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNastavnoPN()
        {
            try
            {
                return new JsonResult(DataProvider.GetNastavnoOsobljePunaNorma());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("UcitajNastavnoBN")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNastavnoBN()
        {
            try
            {
                return new JsonResult(DataProvider.GetNastavnoOsobljeBezNorme());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("UcitajNenastavno")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNenastavno()
        {
            try
            {
                return new JsonResult(DataProvider.GetNenastavnoOsoblje());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



    }
}
