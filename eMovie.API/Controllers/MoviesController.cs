﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMovie.Commons.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace eMovie.API.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IBusClient busClient;

        public MoviesController(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        [Route("")]
        public async Task<IActionResult> Post([FromBody] CreateMovie createMovie)
        {
            try
            {
                await busClient.PublishAsync(createMovie);
                return Accepted($"api/movies/{createMovie.Id}");
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}