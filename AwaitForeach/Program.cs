using System;
using System.Threading.Tasks;

namespace AwaitForeach
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            foreach (var x in new[] { 1, 2, 3 })
            {
                await DoSomethingAsync(x); // Could also be an HTTP call
            }
        }
        
        private static async Task DoSomethingAsync(int x)
        {
            Console.WriteLine($"Doing {x}... ({DateTime.Now :hh:mm:ss})");
            await Task.Delay(2000);
            Console.WriteLine($"{x} done.    ({DateTime.Now :hh:mm:ss})");
        }
    }
}