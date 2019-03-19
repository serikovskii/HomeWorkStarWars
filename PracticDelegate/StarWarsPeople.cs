using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticDelegate
{
    public class StarWarsPeople
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        [JsonProperty(PropertyName = "hair_color")]
        public string HairColor { get; set; }
        [JsonProperty(PropertyName = "skin_color")]
        public string SkinColor { get; set; }
        [JsonProperty(PropertyName = "eye_color")]
        public string EyeColor { get; set; }
        [JsonProperty(PropertyName = "birth_year")]
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public string[] Films { get; set; }
        public string[] Species { get; set; }
        public string[] Vehicles { get; set; }
        public string[] Starships { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }
        
    }
}
