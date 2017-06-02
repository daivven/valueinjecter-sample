using System.Web.Mvc;
using AspNetMVCSample.Models;
using Omu.ValueInjecter;

namespace AspNetMVCSample.Controllers
{
    public class RequestToEntitySampleController : Controller
    {
        public ActionResult Index()
        {
            var person = new PersonRepository().Get();

            var personViewModel = new PersonViewModel();
            personViewModel.InjectFrom<LoopValueInjection>(person)
                .InjectFrom<CountryToLookup>(person);

            //or you could just use ViewData["FirstName"] = "Value" it's the same thing
            //your just not going to be able to use strongly typed html editor helpers
            return View(personViewModel);
        }

        [HttpPost]
        public ActionResult Index(object differentSignature)
        {
            var person = new Person();
            person.InjectFrom<RequestToSimpleTypes>(Request)
                .InjectFrom<RequestToCountry>(Request);

            return Content("the result from the FormCollection is: ".InjectFrom<Describe>(person).ToString());
        }
    }
}