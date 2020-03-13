using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATXBSAPP.ViewModels
{
    class NewsViewModel
    {
        public string TituloN { get; set; }
        public string FotoN { get; set; }
        public string UrlN { get; set; }
        public string TextoN { get; set; }
        public string AutorN { get; set; }
        public string FechaN { get; set; }
         [JsonProperty("value")]
        public Value Value { get; set; }

    }
    public class Value
    {
        [JsonProperty("adx_name")]
        public string Adx_name { get; set; }
    }
}
