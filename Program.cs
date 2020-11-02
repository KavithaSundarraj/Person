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
solution using class
* 2.Salary Increase
* Refactor project from last task.
Read person with their names, age and salary. Read percent bonus to every person salary. People younger than 30 get half the increase. Expand Person from the previous task.
New fields and methods:
•	salary: decimal 
•	IncreaseSalary(decimal percentage)
 */


namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter no of Persons: ");
            var lines = int.Parse(Console.ReadLine()); 
            var persons = new List<Person>();
            Console.WriteLine("Please enter the Persons details by FirstName, LastName, Age and Salary:");
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                persons.Add(person);
            }

            /*Console.WriteLine("After Sort Persons by Name and Age:");
            persons.OrderBy(p => p.Firstname)
                   .ThenBy(p => p.Age)
                   .ToList()
                   .ForEach(p => Console.WriteLine(p.ToString()));   */
            Console.WriteLine("Enter Bonus for Persons :");
            var bonus = decimal.Parse(Console.ReadLine());
            Console.WriteLine("After calculating Bonus Percentage for Persons :");
            persons.ForEach(p => p.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p.ToString()));


        }
    }

    class Person
    {
        private string firstname;
        private string lastname;
        private int age;
        private decimal salary;

        public Person(String firstname, String lastname, int  age, decimal salary)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
            this.salary = salary;
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
            return $"{this.firstname} {this.lastname} receives {this.salary} dollars.";
        }

        public void IncreaseSalary (decimal percentage)
        {
            if(this.Age > 30)
            {
                this.salary += this.salary * percentage / 100;
                    
            }
            else
            {
                this.salary += this.salary * percentage / 200;
            }
        }
    }
}
