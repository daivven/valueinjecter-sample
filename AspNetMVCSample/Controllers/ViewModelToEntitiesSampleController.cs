using System.Web.Mvc;
using AspNetMVCSample.Models;
using Omu.ValueInjecter;

namespace AspNetMVCSample.Controllers
{
    public class ViewModelToEntitiesSampleController : Controller
    {
        public ActionResult Index()
        {
            var foo = new Foo { Name = "Athene", Text = "text", Country = new CountryRepository().Get(23) };
            var bar = new Bar
                          {
                              Name = "bar",
                              Number = 123,
                              Text = "bar text",
                              Country = new CountryRepository().Get(8),
                          };

            var foobar = new FooBarViewModel();
            foobar.InjectFrom(new LoopValueInjection().TargetPrefix("Foo"), foo)
                .InjectFrom(new LoopValueInjection().TargetPrefix("Bar"), bar)
                .InjectFrom(new CountryToLookup().TargetPrefix("Foo"), foo)
                .InjectFrom(new CountryToLookup().TargetPrefix("Bar"), bar);

            return View(foobar);
        }

        [HttpPost]
        public ActionResult Index(FooBarViewModel fooBarViewModel)
        {
            var foo = new Foo();
            var bar = new Bar();

            foo.InjectFrom(new LoopValueInjection().SourcePrefix("Foo"), fooBarViewModel)
                .InjectFrom(new LookupToCountry().SourcePrefix("Foo"), fooBarViewModel);

            bar.InjectFrom(new LoopValueInjection().SourcePrefix("Bar"), fooBarViewModel)
                .InjectFrom(new LookupToCountry().SourcePrefix("Bar"), fooBarViewModel);

            return Content(
                "foo <br/>".InjectFrom<Describe>(foo).ToString() 
                + "bar <br/>".InjectFrom<Describe>(bar));
        }
    }
}