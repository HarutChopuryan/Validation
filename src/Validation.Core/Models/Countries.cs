using System.Collections.Generic;
using Newtonsoft.Json;

namespace Validation.Core.Models
{
    public class Countries
    {
        [JsonProperty("name")]
        public List<string> CountryNames { get; set; }
    }
}