using System.Web.Mvc;
using AspNetMVCSample.Models;
using Omu.ValueInjecter;

namespace AspNetMVCSample.Controllers
{
    public class FlatUnflatController : Controller
    {
        public ActionResult Index()
        {
            var unflat = new Unflat
                             {
                            Country = new CountryRepository().Get(3),
                            Name = "unflatty",
                            Number = 32,
                            Parent = new Unflat
                                         {
                                             Country = new CountryRepository().Get(45),
                                             Name = "parent",
                                             Number = 23,
                                             Parent = new Unflat
                                                          {
                                                              Country = new CountryRepository().Get(9),
                                                              Name = "parent of the parent",
                                                              Number = 87
                                                          }
                                         }
                        };

            var flat = new FlatViewModel();

            flat.InjectFrom<FlatLoopValueInjection>(unflat)
                .InjectFrom<FlatCountryToLookup>(unflat);

            return View(flat);
        }

        [HttpPost]
        public ActionResult Index(FlatViewModel flatViewModel)
        {
            var unflat = new Unflat();

            unflat.InjectFrom<UnflatLoopValueInjection>(flatViewModel)
                .InjectFrom<UnflatLookupToCountry>(flatViewModel);

            return Content("The result is: </br> unflat "
                .InjectFrom<Describe>(unflat).ToString()
                + "<hr/>parent <br/>".InjectFrom<Describe>(unflat.Parent)
                + "<hr/>parent of parent :) <br/>".InjectFrom<Describe>(unflat.Parent.Parent));
        }
    }
}