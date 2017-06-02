using System;

namespace Test
{
    public class Valid
    {
        public static void Required(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("this field is required");
        }

    }
}