﻿using System;


public class Person
{
    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"First name cannot contain fewer than 3 symbols!");
            }
            this.firstName = value;
        }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"Last name cannot contain fewer than 3 symbols!");
            }
            this.lastName = value;
        }
    }

    private string fullName;

    public string FullName
    {
        get { return this.firstName + " " + this.lastName; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        private set
        {
            if (value < 460)
            {
                throw  new ArgumentException("Salary cannot be less than 460 leva!");
            }
            this.salary = value;
        }
    }


    public Person()
    {

    }
    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
      
    }
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.age > 30)
        {
            this.salary += this.salary * (percentage / 100);
        }
        else
        {
            this.salary += this.salary * (percentage / 200);
        }
        // return this.salary;
    }

    public override string ToString()
    {
        return $"{FullName} receives {this.salary:f2} leva.";
    }
}
