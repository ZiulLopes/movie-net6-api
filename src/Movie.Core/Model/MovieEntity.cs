using Newtonsoft.Json;

namespace Movie.Core.Model
{
    public class MovieEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("date_add")]
        public string DateAdd { get; set; }

        [JsonProperty("yaer")]
        public int Year { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }
    }
}
