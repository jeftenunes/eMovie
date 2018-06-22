using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMovie.Commons.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace eMovie.API.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IBusClient busClient;

        public UsersController(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        [Route("")]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            await busClient.PublishAsync(createUser);
            return Accepted($"users/{createUser.Id}");
        }
    }
}