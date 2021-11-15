using MyTopArtistsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTopArtistsWebApp
{
    public interface ISpotifyService
    {
        Task<IEnumerable<TopArtists>> GetTopArtists(int limit, string accessToken);
    }
}
