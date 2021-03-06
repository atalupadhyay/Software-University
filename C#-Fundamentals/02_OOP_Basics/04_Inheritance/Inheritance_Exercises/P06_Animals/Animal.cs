﻿using System;


    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }
    
        public int Age
        {
            get { return age; }
            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
    
        public virtual string Gender
        {
            get { return gender; }
            set
            {
                if ( string.IsNullOrWhiteSpace(value) || (value.ToLower() != "male" && value.ToLower() != "female"))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "Say animal";
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
    }


