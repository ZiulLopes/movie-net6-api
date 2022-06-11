using Newtonsoft.Json;

namespace Movie.Core.Request
{
    public class MovieRequest
    {
        [JsonProperty("movie_id")]
        public int MovieId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("date_add")]
        public string DateAdd { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }
    }
}
