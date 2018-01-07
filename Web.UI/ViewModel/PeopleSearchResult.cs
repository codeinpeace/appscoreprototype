using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ancestry.Web.UI.ViewModel
{
    public class PeopleSearchResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public int BirthplaceId { get; set; }
        public string Birthplace { get; set; }

    }       
}
            