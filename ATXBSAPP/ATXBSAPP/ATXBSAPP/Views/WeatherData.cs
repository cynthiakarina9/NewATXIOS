using Newtonsoft.Json;

namespace ATXBSAPP.Views
{
    public class WeatherData
    {
        /* [JsonProperty("name")]
         public string Title { get; set; }

         [JsonProperty("weather")]
         public Weather[] Weather { get; set; }

         [JsonProperty("main")]
         public Main Main { get; set; }

         [JsonProperty("visibility")]
         public long Visibility { get; set; }

         [JsonProperty("wind")]
         public Wind Wind { get; set; }

         [JsonProperty("clouds")]
         public Clouds Clouds { get; set; }*/

        [JsonProperty("value")]
        public Value Value { get; set; }

    }

    /* public class Main
     {
         [JsonProperty("temp")]
         public double Temperature { get; set; }

         [JsonProperty("humidity")]
         public long Humidity { get; set; }
     }

     public class Clouds
     {
         [JsonProperty("all")]
         public string All { get; set; }
     }

     public class Weather
     {
         [JsonProperty("main")]
         public string Visibility { get; set; }
     }

     public class Wind
     {
         [JsonProperty("speed")]
         public double Speed { get; set; }
     }*/

    public class Value
    {
        [JsonProperty("adx_name")]
        public string Adx_name { get; set; }
    }
}
