﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelOrDigit
{
    class StartUp
    {
        static void Main(string[] args)
        {

            char input =char.Parse(Console.ReadLine());

            if (input == 'a' || input == 'e' || input== 'u'|| input=='o' || input=='i')
            {
                Console.WriteLine($"vowel");
            }
            else if (char.IsDigit(input))
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
