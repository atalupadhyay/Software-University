﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCounter
{
    class CaloriesCounter
    {
        static void Main(string[] args)
        {
            int numberOfIngredients = int.Parse(Console.ReadLine());
            int totalCalories = 0;


            for (int i = 0; i < numberOfIngredients; i++)
            {
                string ingredient = Console.ReadLine().ToLower();

                if (ingredient == "cheese")
                {
                    totalCalories += 500;
                }
                else if (ingredient == "tomato sauce")
                {
                    totalCalories += 150;
                }
                else if (ingredient == "salami")
                {
                    totalCalories += 600;
                }
                else if (ingredient == "pepper")
                {
                    totalCalories += 50;
                }
            }
            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
