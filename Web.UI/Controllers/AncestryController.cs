using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ancestry.Web.UI.Helpers;
using Ancestry.Web.UI.ViewModel;
using AncestryPrototype.Data;
using Microsoft.AspNetCore.Mvc;
 

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    public class AncestryDataController : Controller
    {

        private readonly AncestryContext _context;

        public AncestryDataController(AncestryContext context)
        {
            _context = context;
        }


        [HttpGet("[action]")]
        public IEnumerable<PeopleSearchResult> GetAncestors(string name)
        {
            //IMPORTANT: If this was not a prototype, I would have put this into a repository layer and implemented proper domain model
            var ancestors = _context.People.ToList().ToPeopleSearchResult();
            return ancestors;
        }
         
        
    }
}
