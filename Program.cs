using System;
using System.Collections.Generic;
//using System.Linq;
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
* 4.	First and Reserve Team
* Create a Team class. Add to this team all people you read. All people younger than 40 go on the first team,
* others go on the reverse team. At the end print the first and reserve team sizes.
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
            /* Console.WriteLine("Enter Bonus for Persons :");
             var bonus = decimal.Parse(Console.ReadLine());
             Console.WriteLine("After calculating Bonus Percentage for Persons :");
             persons.ForEach(p => p.IncreaseSalary(bonus));
             persons.ForEach(p => Console.WriteLine(p.ToString())); */

            Team team = new Team("Lexicon");
            foreach(Person p in persons)
            {
                team.AddPlayer(p);

            }
            Console.WriteLine("Team :");
            Console.WriteLine(team.ToString());


        }
    }

    class Team
    {
        private String name;
        private List<Person> firstteam;
        private List<Person> reserveteam;


        private List<Person> Firstteam
        {
            get
            {
                return this.firstteam;
            }
        }
        private List<Person> Reserveteam
        {
            get
            {
                return this.reserveteam;
            }
        }
        public Team(String name)
        {
            this.firstteam = new List<Person>();
            this.reserveteam = new List<Person>();
            this.name = name;

        }
        public void AddPlayer(Person player)
        {
            if(player.Age < 40)
            {
                firstteam.Add(player);
            }
            else
            {
                reserveteam.Add(player);
            }
        }
        public override string ToString()
        {
            return $"Firstteam has {this.firstteam.Count} players.\nReserve team has {this.reserveteam.Count} players. ";
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

             set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                    //Console.WriteLine("First name cannot contain fewer than 3 symbols!");
                }
                this.firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return this.lastname;
            }

           set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                    //Console.WriteLine("Last name cannot contain fewer than 3 symbols!");
                }
                this.lastname = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
          set
            {
                if (value  <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                    //Console.WriteLine("Age cannot be zero or a negative integer!");
                }
                this.age = value;
            }
        }
        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 dollar!");
                    //Console.WriteLine("Salary cannot be less than 460 dollar!");
                }
                this.salary = value;
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
