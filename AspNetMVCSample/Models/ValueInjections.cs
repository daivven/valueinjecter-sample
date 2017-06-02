using System;
using System.Linq;
using System.Web.Mvc;
using Omu.ValueInjecter;
using System.Web;

namespace AspNetMVCSample.Models
{
    public class Describe : KnownTargetValueInjection<string>
    {
        protected override void Inject(object source, ref string target)
        {
            var sourceProps = source.GetProps();
            for (var index = 0; index < sourceProps.Count; index++)
            {
                var sourceProp = sourceProps[index];
                target += sourceProp.Name + " = " + sourceProp.GetValue(source) + " <br/>";
            }
        }
    }

    public class CountryToLookup : LoopValueInjection<Country, object>
    {
        protected override object SetValue(Country sourcePropertyValue)
        {
            var value = sourcePropertyValue ?? new Country();
            var countries = new CountryRepository().GetAll().ToArray();
            return
                countries.Select(
                    o => new SelectListItem
                             {
                                 Text = o.Name,
                                 Value = o.Id.ToString(),
                                 Selected = value.Id == o.Id
                             });
        }
    }

    public class LookupToCountry : LoopValueInjection<object, Country>
    {
        protected override Country SetValue(object sourcePropertyValue)
        {
            var selectedValue = Convert.ToInt32((((string[])sourcePropertyValue)[0]));
            return new CountryRepository().Get(selectedValue);
        }
    }
    
    public class RequestToSimpleTypes : KnownSourceValueInjection<HttpRequestBase>
    {
        protected override void Inject(HttpRequestBase request, object target)
        {
            var targetProps = target.GetProps();
            for (var i = 0; i < targetProps.Count; i++)
            {
                var activeTarget = targetProps[i];
                if (!new[] { typeof(int), typeof(long), typeof(string), typeof(DateTime) }
                    .Contains(activeTarget.PropertyType)) continue;

                var value = request[activeTarget.Name];
                if (String.IsNullOrEmpty(value)) continue;

                activeTarget.SetValue(target, Convert.ChangeType(value, activeTarget.PropertyType));
            }
        }
    }

    public class RequestToCountry : KnownSourceValueInjection<HttpRequestBase>
    {
        protected override void Inject(HttpRequestBase request, object target)
        {
            var targetProps = target.GetProps();
            for (var i = 0; i < targetProps.Count; i++)
            {
                var activeTarget = targetProps[i];
                if (activeTarget.PropertyType != typeof(Country)) continue;

                var value = Convert.ToInt32(request[activeTarget.Name]);
                if (value == 0) continue;

                activeTarget.SetValue(target, new CountryRepository().Get(value));
            }
        }
    }

    public class FormCollectionToSimpleTypes : KnownSourceValueInjection<FormCollection>
    {
        protected override void Inject(FormCollection formCollection, object target)
        {
            var targetProps = target.GetProps();
            for (var i = 0; i < targetProps.Count; i++)
            {
                var activeTarget = targetProps[i];
                if (!new[] { typeof(int), typeof(long), typeof(string), typeof(DateTime) }
                    .Contains(activeTarget.PropertyType)) continue;

                var value = formCollection[activeTarget.Name];
                if (String.IsNullOrEmpty(value)) continue;

                activeTarget.SetValue(target, Convert.ChangeType(value, activeTarget.PropertyType));
            }
        }
    }

    public class FormCollectionToCountry : KnownSourceValueInjection<FormCollection>
    {
        protected override void Inject(FormCollection formCollection, object target)
        {
            var targetProps = target.GetProps();
            for (var i = 0; i < targetProps.Count; i++)
            {
                var activeTarget = targetProps[i];
                if (activeTarget.PropertyType != typeof(Country)) continue;

                var value = Convert.ToInt32(formCollection[activeTarget.Name]);
                if (value == 0) continue;

                activeTarget.SetValue(target, new CountryRepository().Get(value));
            }
        }
    }

    public class FlatCountryToLookup : FlatLoopValueInjection<Country, object>
    {
        protected override object SetValue(Country sourcePropertyValue)
        {
            var value = sourcePropertyValue ?? new Country();
            var countries = new CountryRepository().GetAll().ToArray();
            return
                countries.Select(
                    o => new SelectListItem
                    {
                        Text = o.Name,
                        Value = o.Id.ToString(),
                        Selected = value.Id == o.Id
                    });
        }
    }

    public class UnflatLookupToCountry : UnflatLoopValueInjection<object, Country>
    {
        protected override Country SetValue(object sourcePropertyValue)
        {
            var selectedValue = Convert.ToInt32((((string[])sourcePropertyValue)[0]));
            return new CountryRepository().Get(selectedValue);
        }
    }


}
