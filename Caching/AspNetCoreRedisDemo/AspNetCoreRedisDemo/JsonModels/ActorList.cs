using Newtonsoft.Json;
using System.Collections.Generic;

namespace AspNetCoreRedisDemo.JsonModels
{
    public class ActorList
    {
        [JsonProperty("results")]
        public List<Actor> Actors { get; set; }
    }
}
