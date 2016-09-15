using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var Path = @"C:\Users\Madan\Documents\Visual Studio 2013\Projects\Scheduler\Scheduler\Temp.txt";

            if (File.Exists(Path))
            {
                var List = File.ReadAllLines(Path);
                Console.WriteLine("Total days so far : {0}", List.Count());
                SortedDictionary<DateTime, string> Modules = new SortedDictionary<DateTime, string>();
                foreach (var itemc in List)
                {
                    var dateval = itemc.Split(':').ToList();
                    DateTime Date;

                    if (DateTime.TryParse(dateval[0], out Date))
                        Modules.Add(Date, dateval[1]);

                }

                var Beginning = Modules.First().Key;
                var Today = DateTime.Parse("20/Sep/2016");
                int TotalDays = (Today - Beginning).Days;

                string[] Revistory = new string[TotalDays];

                for (int i = 0; i < TotalDays; i++)
                {
                    Revistory[i] += Modules.ElementAt(i).Value + ", ";
                    int Skip = 1;
                    int Reset = 1;
                    for (int j = i + 1; j < TotalDays; j++)
                    {
                        if (Reset > Skip)
                        {
                            Revistory[j] += Modules.ElementAt(i).Value + ", ";
                            Skip++;
                            Reset = 1;
                            continue;
                        }
                        Reset++;
                    }
                }

            }
        }
    }
}
