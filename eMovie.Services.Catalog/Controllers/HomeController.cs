using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMovie.Services.Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMovie.Services.Catalog.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;

        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet("")]
        public IActionResult Get() => Ok(movieService.Get());
    }
}