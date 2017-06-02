using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Omu.ValueInjecter;

namespace DALSample
{
    public class SetParamsValues : KnownTargetValueInjection<SqlCommand>
    {
        private IEnumerable<string> ignoredFields = new string[] { };
        private string prefix = string.Empty;

        public SetParamsValues Prefix(string p)
        {
            prefix = p;
            return this;
        }

        public SetParamsValues IgnoreFields(params string[] fields)
        {
            ignoredFields = fields.AsEnumerable();
            return this;
        }

        protected override void Inject(object source, ref SqlCommand cmd)
        {
            if (source == null) return;
            var sourceProps = source.GetProps();

            for (var i = 0; i < sourceProps.Count; i++)
            {
                var prop = sourceProps[i];
                if (ignoredFields.Contains(prop.Name)) continue;

                var value = prop.GetValue(source) ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@" + prefix + prop.Name, value);
            }
        }
    }
}