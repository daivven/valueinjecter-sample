using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Omu.ValueInjecter.Silverlight;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = new MapFrom();
            from.Property1 = "hi";
            var to = new MapTo();

            to.InjectFrom<Inj1>(from);
            Console.WriteLine(to.Property1);
        }
    }

    public class Validator
    {
        public string this[string columnName] { get { throw new NotImplementedException(); } }
    }

    public class MapFrom : Validator
    {
        public string Property1 { get; set; }
    }

    public class MapTo
    {
        public string Property1 { get; set; }
    }

    public class Inj1 : SmartConventionInjection
    {
        protected override bool Match(SmartConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name;
        }
    }

    public abstract class SmartConventionInjection : ValueInjection
    {
        private class Path
        {
            public Type Source { get; set; }
            public Type Target { get; set; }
            public IDictionary<string, string> Pairs { get; set; }
        }

        protected abstract bool Match(SmartConventionInfo c);

        private static readonly IList<Path> paths = new List<Path>();
        private static readonly IDictionary<Type, Type> wasLearned = new Dictionary<Type, Type>();

        private Path Learn(object source, object target)
        {
            Path path = null;
            var sourceProps = source.GetProps();
            var targetProps = target.GetProps();
            var sci = new SmartConventionInfo
            {
                SourceType = source.GetType(),
                TargetType = target.GetType()
            };

            for (var i = 0; i < sourceProps.Count(); i++)
            {
                var s = sourceProps[i];
                sci.SourceProp = s;

                for (var j = 0; j < targetProps.Count(); j++)
                {
                    var t = targetProps[j];
                    sci.TargetProp = t;

                    if (!Match(sci)) continue;
                    if (path == null)
                        path = new Path
                        {
                            Source = sci.SourceType,
                            Target = sci.TargetType,
                            Pairs = new Dictionary<string, string> { { sci.SourceProp.Name, sci.TargetProp.Name } }
                        };
                    else path.Pairs.Add(sci.SourceProp.Name, sci.TargetProp.Name);
                }
            }
            return path;
        }

        protected override void Inject(object source, object target)
        {
            var sourceProps = source.GetProps();
            var targetProps = target.GetProps();

            if (!wasLearned.Contains(new KeyValuePair<Type, Type>(source.GetType(), target.GetType())))
            {
                lock (wasLearned)
                {
                    if (!wasLearned.Contains(new KeyValuePair<Type, Type>(source.GetType(), target.GetType())))
                    {

                        var match = Learn(source, target);
                        wasLearned.Add(source.GetType(), target.GetType());
                        if (match != null) paths.Add(match);
                    }
                }
            }

            var path = paths.SingleOrDefault(o => o.Source == source.GetType() && o.Target == target.GetType());

            if (path == null) return;

            foreach (var pair in path.Pairs)
            {
                var sp = sourceProps.GetByName(pair.Key);
                var tp = targetProps.GetByName(pair.Value);
                var setValue = true;
                var val = SetValue(ref setValue, new SmartValueInfo { Source = source, Target = target, SourceProp = sp, TargetProp = tp, SourcePropValue = sp.GetValue(source) });
                if (setValue) tp.SetValue(target, val);
            }
        }

        protected virtual object SetValue(ref bool setValue, SmartValueInfo info)
        {
            return info.SourcePropValue;
        }
    }

    public class SmartValueInfo
    {
        public PropertyInfo SourceProp { get; set; }
        public PropertyInfo TargetProp { get; set; }
        public object Source { get; set; }
        public object Target { get; set; }
        public object SourcePropValue { get; set; }
    }

    public class SmartConventionInfo
    {
        public Type SourceType { get; set; }
        public Type TargetType { get; set; }

        public PropertyInfo SourceProp { get; set; }
        public PropertyInfo TargetProp { get; set; }
    }
}
