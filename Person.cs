using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }   
        public string PhoneNumber { get; set; }

        public void UpdateContactInfo (string newPhoneNumber)
        {
            PhoneNumber = newPhoneNumber;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Name = {Name}, Age = {Age}, PhoneNumber = {PhoneNumber}");
            
        }

    }
}
