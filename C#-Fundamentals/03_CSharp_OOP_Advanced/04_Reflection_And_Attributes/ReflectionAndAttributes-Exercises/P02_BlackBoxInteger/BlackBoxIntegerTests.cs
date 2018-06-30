﻿using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {

            Type type = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");
            FieldInfo innerValue = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic);

            object instance = Activator.CreateInstance(type, true);
            
            string commandArgs;
            while ((commandArgs = Console.ReadLine()) != "END")
            {
                string[] tokens = commandArgs.Split('_');
                string command = tokens[0];
                int number = int.Parse(tokens[1]);

                MethodInfo method = methods.First(n => n.Name == command);

                method.Invoke(instance, new object[] {number});

                Console.WriteLine(innerValue.GetValue(instance));
            }
        }
    }
}
