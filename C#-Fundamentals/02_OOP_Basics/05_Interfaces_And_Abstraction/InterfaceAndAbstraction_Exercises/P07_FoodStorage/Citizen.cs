﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodStorage
{
     class Citizen:IInfo,IBuyer
    {
        public string Type { get; } = "Citizen";
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }

        public int Food { get; set; } = 0;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
