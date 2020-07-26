using Newtonsoft.Json;

namespace AspNetCoreRedisDemo.JsonModels
{
    public class Movie
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
