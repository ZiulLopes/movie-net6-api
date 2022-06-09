using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Response
{
    public class MovieResponse
    {
        [JsonProperty("movie_id")]
        public int MovieId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
