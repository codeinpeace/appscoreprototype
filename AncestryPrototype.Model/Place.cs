using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncestryPrototype.Model
{
    public class Place
    {

        [Key]
        public int PlaceId { get; set; }
        public string Name { get; set; }
    }
}
