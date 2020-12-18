using AdventOfCode.Shared.Contracts;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.ConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var arguments = args.ToList();

            Console.WriteLine("Hello and welcome to my Advent of Code App.");
            while(arguments.Count() < 3)
            {
                Console.WriteLine("I`m sorry, but there is a problem with passed arguments." +
                    "\nFirst argument must be a year." +
                    "\nSecond argument must be a day." +
                    "\nOther arguments are for task." +
                    "\n\nPass parameters:");
                var readLine = Console.ReadLine();
                arguments = readLine.Split(" ").ToList();
            }

            await ExecuteTask(arguments);

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static async Task ExecuteTask(List<string> args)
        {
            var serviceKey = $"{args[0]}-{args[1]}";
            args.RemoveRange(0, 2);

            DryIocContainer.Configure();
            using (var container = DryIocContainer.ApplicationContainer.OpenScope())
            {
                var task = container.Resolve<IAdventTask>(serviceKey);

                Console.WriteLine($"Executing task {task.GetType().Name}.");

                Console.WriteLine($"Starts at {DateTime.Now}.");
                var result = await task.Execute(args).ConfigureAwait(false);
                Console.WriteLine($"\n-----\nResult of task: {result}.\n-----\n");
                Console.WriteLine($"Ends at {DateTime.Now}.");

            }
        }
    }
}
