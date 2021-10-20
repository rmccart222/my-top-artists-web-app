using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTopArtistsWebApp
{
    public interface ISpotifyAccountService
    {
        Task<string> GetToken(string clientId, string clientSecret);
    }
}
