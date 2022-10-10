using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShorteningService.Business.Abstract;
using URLShorteningService.Business.Dto;

namespace URLShorteningService.API.Controllers
{
    [Route("/")]
    public class RedirectController : Controller
    {
        private IRedirectService _redirectService;
        public RedirectController(IRedirectService redirectService)
        {
            _redirectService = redirectService;
        }
        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            try
            {
                var url = _redirectService.GetURLByCode(code);
                return Redirect(url);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetUrlByCode")]
        public IActionResult GetUrlByCode([FromBody] GetUrlByCodeDto getUrlByCodeDto)
        {
            try
            {
                return Ok(_redirectService.GetURLByCode(getUrlByCodeDto.Code));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
