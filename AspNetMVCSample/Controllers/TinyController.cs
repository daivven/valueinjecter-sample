using System.Web.Mvc;
using AspNetMVCSample.Models;
using Omu.ValueInjecter;

namespace AspNetMVCSample.Controllers
{
    public class TinyController : Controller
    {
        private readonly IModelBuilder<Person, PersonViewModel> modelBuilder;

        public TinyController()
        {
            modelBuilder = new PersonModelBuilder();
        }

        public ActionResult Index()
        {
            return View(modelBuilder.BuildModel(new PersonRepository().Get()));
        }

        [HttpPost]
        public ActionResult Index(PersonViewModel model)
        {
            if (!ModelState.IsValid)
                return View(modelBuilder.RebuildModel(model));

            return Content("The result is:<br/>".InjectFrom<Describe>(modelBuilder.BuildEntity(model)).ToString());
        }
    }


    public class PersonModelBuilder : IModelBuilder<Person, PersonViewModel>
    {
        private readonly ValueInjecter injecter;

        public PersonModelBuilder()
        {
            injecter = new ValueInjecter();
        }

        public PersonViewModel BuildModel(Person o)
        {
            var m = new PersonViewModel();
            injecter.Inject(m, o);
            injecter.Inject<CountryToLookup>(m, o);
            return m;
        }

        public Person BuildEntity(PersonViewModel model)
        {
            var p = new Person();
            injecter.Inject(p, model);
            injecter.Inject<LookupToCountry>(p, model);
            return p;
        }

        public PersonViewModel RebuildModel(PersonViewModel model)
        {
            return BuildModel(BuildEntity(model));
        }
    }


    public interface IModelBuilder<TEntity, TModel>
    {
        TModel BuildModel(TEntity entity);
        TEntity BuildEntity(TModel model);
        TModel RebuildModel(TModel model);
    }
}