using System.Collections.Generic;

namespace AspNetMVCSample.Models
{
    public class CountryRepository
    {
        public Country Get(int id)
        {
            return new Country
                       {
                           Id = id,
                           Name = "Country" + id,
                       };
        }

        public IEnumerable<Country> GetAll()
        {
            for (var i = 1; i < 99; i++)
            {
                yield return Get(i);
            }
        }
    }

    public class PersonRepository
    {
        public Person Get()
        {
            var person = new Person
            {
                Id = 333,
                FirstName = "Bill",
                LastName = "Steel",
                Age = 20,
                MiddleName = "James",
                Radio = 2,
                IsTrue = true,
                Country = new CountryRepository().Get(35),
                Country2 = new CountryRepository().Get(7),
                Country3 = new CountryRepository().Get(9),
            };

            return person;
        }
    }
}
