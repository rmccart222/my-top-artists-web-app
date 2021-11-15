using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTopArtistsWebApp.Models
{
    public class TopArtists
    {
        public string Name { get; set; }
        public string[] Genre { get; internal set; }
        public External_Urls External_Urls { get; internal set; }
        public Image[] Images { get; internal set; }
    }
}
