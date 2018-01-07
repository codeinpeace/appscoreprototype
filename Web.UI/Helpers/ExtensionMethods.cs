using AncestryPrototype.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ancestry.Web.UI.ViewModel;

namespace Ancestry.Web.UI.Helpers
{
    public static class ExtensionMethods
    {
        public static List<PeopleSearchResult> ToPeopleSearchResult(this List<Person> peopleList)
        {
            var result = (from p in peopleList
                          select new PeopleSearchResult
                          {
                              Id = p.PlaceId,
                              Name = p.Name,
                              Gender = p.Gender,
                              BirthplaceId = p.PlaceId
                          }).ToList();

            return result;
        }
    }
}
  