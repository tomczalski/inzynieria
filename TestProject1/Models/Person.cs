using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Models
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public UserAddress Address { get; set; }
    }
}
