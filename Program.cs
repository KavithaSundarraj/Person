using System;
using System.Collections.Generic;
using System.Linq;
/* Lab: Encapsulation
 * Date : 02 Nov 2020
 * 1.	Sort Persons by Name and Age
 * Create a class Person, which should have private fields for:
•	firstName: string
•	lastName: string
•	age: int
•	ToString(): string - override
solution using class*/

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 5 Persons details by FirstName, LastName and Age:");
            var lines = 5;
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
                persons.Add(person);
            }
            Console.WriteLine("After Sort Persons by Name and Age:");
            persons.OrderBy(p => p.Firstname)
                   .ThenBy(p => p.Age)
                   .ToList()
                   .ForEach(p => Console.WriteLine(p.ToString()));

        }
    }

    class Person
    {
        private string firstname;
        private string lastname;
        private int age;
        public Person(String firstname, String lastname, int  age)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
        }
        public string Firstname
        {
            get
            {
                return this.firstname;
            }
           
        }
        public int Age
        {
            get
            {
                return this.age;
            }
        }

        public override string ToString()
        {
            return $" {this.firstname} {this.lastname} is {this.age} years old.";
        }

    }
}
