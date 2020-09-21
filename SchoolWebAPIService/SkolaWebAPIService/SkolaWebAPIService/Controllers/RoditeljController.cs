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
    public class RoditeljController : ControllerBase
    {
        [HttpGet]
        [Route("UcitajRoditelje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRoditelje()
        {
            try
            {
                return new JsonResult(DataProvider.GetRoditelji());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("UcitajRoditelja/{roditeljID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRoditelj(int roditeljID)
        {
            try
            {
                return new JsonResult(DataProvider.GetRoditelj(roditeljID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRoditelja/{UcenikID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajRoditelja([FromBody]RoditeljView u,int UcenikID)
        {
            try
            {
                var ucenik = DataProvider.GetUcenika(UcenikID);
                u.PripadaUceniku = ucenik;
                DataProvider.DodajRoditelja(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiRoditelja/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzbrisiRoditelja(int id)
        {
            try
            {
                DataProvider.IzbrisiRoditelja(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniRoditelja")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniRoditelja([FromBody]RoditeljView u)
        {
            try
            {
                DataProvider.IzmeniRoditelja(u);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
