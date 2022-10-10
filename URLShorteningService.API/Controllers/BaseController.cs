using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShorteningService.API.Controllers
{
    [Route("api/[controller]s")]
    [Produces("application/json")]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }
    }
}
