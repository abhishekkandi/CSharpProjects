using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRedisDemo.Utilities;


namespace AspNetCoreRedisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Please enter the name of the actor/actress at the end of the URL";
        }

        [HttpGet("{actorName}")]
        public async Task<List<string>> Get(string actorName)
        {
            return await TMDBApiCall.GetMovieList(actorName);
        }
    }
}