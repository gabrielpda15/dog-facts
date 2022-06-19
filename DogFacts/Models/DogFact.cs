using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFacts.Models
{
    public class DogFact
    {
        [JsonProperty("facts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IList<string>? Facts { get; set; }
    }
}
