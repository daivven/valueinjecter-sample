using System.Web.Mvc;
using AspNetMVCSample.Models;
using Omu.ValueInjecter;

namespace AspNetMVCSample.Controllers
{
    public class ViewModelToEntitySampleController : Controller
    {
        public ActionResult Index()
        {
            var person = new PersonRepository().Get();

            var personViewModel = new PersonViewModel();
            personViewModel.InjectFrom(person)
                .InjectFrom<CountryToLookup>(person);

            return View(personViewModel);
        }

        [HttpPost]
        public ActionResult Index(PersonViewModel personViewModel)
        {
            var person = new Person();
            person.InjectFrom(personViewModel)
                .InjectFrom<LookupToCountry>(personViewModel);

            if (!ModelState.IsValid)
            {
                var m = new PersonViewModel();
                return View(m.InjectFrom(person)
                    .InjectFrom<CountryToLookup>(person));
            }

            return Content("the result from the PersonViewModel is: <br/>".InjectFrom<Describe>(person).ToString());

        }
    }
}