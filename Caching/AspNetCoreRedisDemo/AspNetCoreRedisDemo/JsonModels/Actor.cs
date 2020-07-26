using Newtonsoft.Json;

namespace AspNetCoreRedisDemo.JsonModels
{
    public class Actor
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
