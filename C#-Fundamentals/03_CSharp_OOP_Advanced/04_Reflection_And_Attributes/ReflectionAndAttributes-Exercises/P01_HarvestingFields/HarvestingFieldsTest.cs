﻿ using System.Collections.Generic;
 using System.Linq;
 using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            //string command;
            //while ((command = Console.ReadLine())!= "HARVEST")
            //{
            //    var harvesterReflection = new HarvestReflection();
            //    string result = harvesterReflection.SortFields("P01_HarvestingFields.HarvestingFields", command);
                
            //    Console.WriteLine(result);
            //}

            Type type = Type.GetType("P01_HarvestingFields.HarvestingFields");
            FieldInfo[] allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string command;
            while ((command = Console.ReadLine())!= "HARVEST")
            {
                IEnumerable<FieldInfo> fieldsToPrint = null;
                switch (command)
                {
                    case "public":
                        fieldsToPrint = allFields.Where(f=>f.IsPublic);
                        break;

                    case "protected":
                        fieldsToPrint = allFields.Where(f=>f.IsFamily);
                        break;

                    case "private":
                        fieldsToPrint = allFields.Where(f=>f.IsPrivate);
                        break;

                    case "all":
                        fieldsToPrint = allFields;
                        break;
                        
                }

                foreach (var field in fieldsToPrint)
                {
                   Print(field);
                }
            }

        }

        private static void Print(FieldInfo field)
        {
            string access = field.Attributes.ToString().ToLower();
            if (field.Attributes == FieldAttributes.Family)
                access = "protected";

            string fieldString = $"{access} {field.FieldType.Namespace} {field.Name}";

            Console.WriteLine(fieldString);
        }
    }
}
