namespace AspNetMVCSample.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public bool IsTrue { get; set; }
        public int Radio { get; set; }
        public Country Country { get; set; }
        public Country Country2 { get; set; }
        public Country Country3 { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }

    public class Foo
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Country Country { get; set; }
    }

    public class Bar
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public Country Country { get; set; }
    }

    public class Unflat
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public Unflat Parent { get; set; }
        public Country Country { get; set; }
    }

}
