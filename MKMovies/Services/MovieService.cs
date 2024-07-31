using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using MKMovies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MKMovies.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        public MovieService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Movie>> GetPopular()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb8.p.rapidapi.com/title/v2/get-popular?first=20&country=US&language=en-US"),
                Headers =
            {
                { "x-rapidapi-key", "a66b09b652msh14a735e7d8e6439p1fa476jsnf09f715f8d65" },
                { "x-rapidapi-host", "imdb8.p.rapidapi.com" },
            },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var movies = new List<Movie>();
                var json = JObject.Parse(body);
                var movieNodes = json["data"]["movies"]["edges"];
                foreach (var item in movieNodes)
                {
                    var node = item["node"];
                    var movie = new Movie
                    {
                        Id = node["id"].ToString(),
                        Title = node["titleText"]?["text"]?.ToString(),
                        Plot = node["plot"]?["plotText"]?["plainText"]?.ToString(),
                        ImageUrl = node["primaryImage"]?["url"]?.ToString(),
                        Rating = node["ratingsSummary"]?["aggregateRating"]?.ToString()
                    };
                    movies.Add(movie);
                }
                return movies;
            }
        }
        public async Task<Movie> GetMovieByName(string name)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/find?q={Uri.EscapeDataString(name)}"),
                Headers =
                {
                    { "x-rapidapi-key", "a66b09b652msh14a735e7d8e6439p1fa476jsnf09f715f8d65" },
                    { "x-rapidapi-host", "imdb8.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(body);
                var movieNode = json["results"]?.FirstOrDefault();
                if (movieNode != null)
                {
                    var movie = new Movie
                    {
                        Id = movieNode["id"].ToString(),
                        Title = movieNode["title"]?["text"]?.ToString(),
                        Plot = movieNode["plot"]?["plainText"]?.ToString(),
                        ImageUrl = movieNode["primaryImage"]?["url"]?.ToString(),
                        Rating = movieNode["ratingsSummary"]?["aggregateRating"]?.ToString()
                    };
                    return movie;
                }

                return null;
            }
        }
        public async Task<Movie> GetMovieById(string id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/get-details?tconst={id}"),
                Headers =
                {
                    { "x-rapidapi-key", "a66b09b652msh14a735e7d8e6439p1fa476jsnf09f715f8d65" },
                    { "x-rapidapi-host", "imdb8.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(body);
                var movieNode = json["results"];
                    var movie = new Movie
                    {
                        Id = movieNode["id"].ToString(),
                        Title = movieNode["title"]?["text"]?.ToString(),
                        Plot = movieNode["plot"]?["plainText"]?.ToString(),
                        ImageUrl = movieNode["primaryImage"]?["url"]?.ToString(),
                        Rating = movieNode["ratingsSummary"]?["aggregateRating"]?.ToString()
                    };
                    return movie;
            }
        }
    }
}
