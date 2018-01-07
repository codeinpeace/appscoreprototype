using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AncestryPrototype.Model
{
    public class Person
    {

        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        [JsonProperty("father_id")]
        public string FatherId { get; set; }
        //public Person Father { get; set; }

        [JsonProperty("mother_id")]
        public string MotherId { get; set; }
        //public Person Mother  { get; set; }

        [JsonProperty("place_id")]
        public int PlaceId { get; set; }
        public Place Birthplace { get; set; }

        public int Level { get; set; }

    }
}
