using Microsoft.AspNetCore.Mvc;
using System;
using URLShorteningService.Business.Abstract;
using URLShorteningService.Business.Dto;

namespace URLShorteningService.API.Controllers
{
    public class ShorteningController : BaseController
    {
        private IShorteningService _shorteningService;
        public ShorteningController(IShorteningService shorteningService)
        {
            _shorteningService = shorteningService;
        }

        [HttpPost("Shortening")]
        public IActionResult Shortening([FromBody] ShorteningDto shorteningDto)
        {
            try
            {
                var url = _shorteningService.Shortening(shorteningDto);
                return Ok(url);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
