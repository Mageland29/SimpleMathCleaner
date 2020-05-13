using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Context;
using static Logger;

namespace SimpleMathCleaner
{
    class Program
    {
		static Protection[] protects { get; set; } =
		{
            new Protections.CallMath()
		};
		static void Main(string[] args)
        {
            LoadModule(args[0]);
            foreach (Protection protect in protects)
            {
                protect.Run();
            }
            SaveModule();
            Console.ReadLine();
        }
    }
}
