using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string fName, string lName, int age, double salary)
    {
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }

            this.lastName = value;
        }
    }


    public int Age
    {
        get { return this.age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or negative integer");
            }

            this.age = value;
        }
    }


    public double Salary
    {
        get { return this.salary; }
        private set
        {
            if (value < 460)
            {
                throw new ArgumentException("Salary cannot beb less than 460 leva");
            }

            this.salary = value;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {salary:f2} leva";
    }

    public void IncreaseSalary(double percent)
    {
        if (this.age > 30)
        {
            this.salary += this.salary * percent / 100;
        }
        else
        {
            this.salary += this.salary * percent / 200;
        }
    }
}