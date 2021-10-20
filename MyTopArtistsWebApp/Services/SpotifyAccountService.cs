using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyTopArtistsWebApp
{
    public class SpotifyAccountService : ISpotifyAccountService
    {
        private readonly HttpClient _httpClient;
        public SpotifyAccountService(HttpClient httpclient) 
        {
            _httpClient = httpclient;
        }

        public Task<string> GetToken(string clientId, string clientSecret)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "toekn");

            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"}
            });
        }
    }
}
