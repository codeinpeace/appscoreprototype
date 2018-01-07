using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncestryPrototype.Model
{
    public class Ancestor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthplace { get; set; }

    }


    public class SanmpleData 
    {
        public List<Person> People { get; set; } 
        public List<Place> Places { get; set; } 
    }
}
