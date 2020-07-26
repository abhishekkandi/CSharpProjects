using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AspNetCoreRedisDemo.JsonModels;

namespace AspNetCoreRedisDemo.Utilities
{
    public static class TMDBApiCall
    {
        const string url = "https://api.themoviedb.org/3/";
        const string apiKey = "";

        private async static Task<int> GetActorId(string actorName)
        {
            actorName = WebUtility.UrlDecode(actorName);
            string urlParamaters = $"search/person?api_key={apiKey}&query={actorName}";
            var actorList = await HttpUtility.GetAsync<ActorList>(url, urlParamaters);
            if (actorList != null && actorList.Actors.Count > 0)
            {
                return actorList.Actors[0].Id;
            }
            return -1;
        }    

        public async static Task<List<string>> GetMovieList(string actorName)
        {
            var result = new List<string>();

            int id = await GetActorId(actorName);
            string urlParameters = $"person/{id}/movie_credits?api_key={apiKey}&language=en-US";
            var movieList = await HttpUtility.GetAsync<MovieList>(url, urlParameters);
            if (movieList != null)
            {
                foreach (var movie in movieList.Movies)
                {
                    result.Add(movie.Title);
                }
            }
            return result;
        }

    }
}
