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
*3.	Validation of Data
* Expand Person with proper validation for every field:
•	Names must be at least 3 symbols
•	Age must not be zero or negative
•	Salary can't be less than 460.0 
Print proper messages to the user:
•	“Age cannot be zero or a negative integer!”
•	“First name cannot contain fewer than 3 symbols!”
•	“Last name cannot contain fewer than 3 symbols!”
•	“Salary cannot be less than 460 dollar!”
Use ArgumentExeption with messages from example.

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
        public Person(String firstname, String lastname, int  age, decimal salary)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Salary = salary;
        }
        public string Firstname
        {
            get
            {
                return this.Firstname;
            }

             set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                    //Console.WriteLine("First name cannot contain fewer than 3 symbols!");
                }
                this.Firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return this.Lastname;
            }

           set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                    //Console.WriteLine("Last name cannot contain fewer than 3 symbols!");
                }
                this.Lastname = value;
            }
        }
        public int Age
        {
            get
            {
                return this.Age;
            }
          set
            {
                if (value  <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                    //Console.WriteLine("Age cannot be zero or a negative integer!");
                }
                this.Age = value;
            }
        }
        public decimal Salary
        {
            get
            {
                return this.Salary;
            }
            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 dollar!");
                    //Console.WriteLine("Salary cannot be less than 460 dollar!");
                }
                this.Salary = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Firstname} {this.Lastname} receives {this.Salary} dollars.";
        }

        public void IncreaseSalary (decimal percentage)
        {
            if(this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
                    
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }
    }
}
