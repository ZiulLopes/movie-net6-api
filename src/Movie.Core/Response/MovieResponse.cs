using Newtonsoft.Json;

namespace Movie.Core.Response
{
    public class MovieResponse
    {
        [JsonProperty("movie_id")]
        public int movie_id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("date_add")]
        public string date_add { get; set; }

        [JsonProperty("year")]
        public int year { get; set; }

        [JsonProperty("duration")]
        public string duration { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("rate")]
        public string rate { get; set; }
    }
}
