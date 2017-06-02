using System.ComponentModel.DataAnnotations;

namespace AspNetMVCSample.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public bool IsTrue { get; set; }
        public int Radio { get; set; }
        public object Country { get; set; }
        public object Country2 { get; set; }
        public object Country3 { get; set; }
    }

    public class FooBarViewModel
    {
        public string FooName { get; set; }
        public string FooText { get; set; }
        public object FooCountry { get; set; }

        public string BarName { get; set; }
        public string BarText { get; set; }
        public int BarNumber { get; set; }
        public object BarCountry { get; set; }
    }

    public class FlatViewModel
    {
        public string Name { get; set; }
        public object Country { get; set; }
        
        public string ParentName { get; set; }
        public int ParentNumber{ get; set; }
        public object ParentCountry { get; set; } 

        public string ParentParentName { get; set; }
        public int ParentParentNumber { get; set; }
        public object ParentParentCountry { get; set; }
    }
}
