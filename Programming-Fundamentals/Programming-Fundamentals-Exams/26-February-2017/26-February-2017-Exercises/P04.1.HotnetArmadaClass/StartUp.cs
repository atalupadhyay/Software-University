﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04._1.HotnetArmadaClass
{
    class StartUp
    {
        static void Main(string[] args)
        {
             List<Legion> legions = new List<Legion>();
            // Dictionary<string, Legion> dict = new Dictionary<string, Legion>();

            int n = int.Parse(Console.ReadLine());

            for (long i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new string[] { " = ", " -> ", ":" },
                    StringSplitOptions.RemoveEmptyEntries);

                long activity = long.Parse(inputArgs[0]);
                string legion = inputArgs[1];
                string soldier = inputArgs[2];
                long count = long.Parse(inputArgs[3]);

                if (!legions.Any(l => l.Name == legion))
                {
                   Legion currentLegion = new Legion()
                   {
                       Activity = activity,
                       Name = legion,
                       Soldiers = new Dictionary<string, long>()
                   };

                    currentLegion.Soldiers.Add(soldier,count);

                    legions.Add(currentLegion);
                }
                else
                {
                    Legion currentLegion = legions
                        .FirstOrDefault(l => l.Name == legion);

                    if (currentLegion.Activity < activity)
                    {
                        currentLegion.Activity = activity;
                    }

                    if (!currentLegion.Soldiers.ContainsKey(soldier))
                    {
                        currentLegion.Soldiers.Add(soldier,count);
                    }
                    else
                    {
                        currentLegion.Soldiers[soldier] += count;
                    }
                }
            }

            var printArgs = Console.ReadLine().Split('\\');

            if (printArgs.Length > 1)
            {
                long activity = long.Parse(printArgs[0]);
                string soldier = printArgs[1];
                Dictionary<string, long> rem = new Dictionary<string, long>();

                foreach (var legion in legions
                    .Where(l=>l.Activity < activity)
                    .Where(l=>l.Soldiers.ContainsKey(soldier)))
                    
                {
                    rem.Add(legion.Name, legion.Soldiers[soldier]);
                }

                foreach (var pair in rem.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value}");
                }
            }
            else
            {
                string soldier = printArgs[0];

                Dictionary<string, long> rem = new Dictionary<string, long>();

                foreach (var legion in legions
                    .Where(l => l.Soldiers.ContainsKey(soldier)))
                {
                rem.Add(legion.Name,legion.Activity);
                }
                foreach (var pair in rem.OrderByDescending(a=>a.Value))
                {
                    Console.WriteLine($"{pair.Value} : {pair.Key}");
                }
            }
        }
    }

    class Legion 
    {
        public string Name { get; set; }

        public long Activity { get; set; }

        public Dictionary<string, long> Soldiers { get; set; }
        
    }
}
