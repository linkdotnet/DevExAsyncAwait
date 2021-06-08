using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NoSyncDeadlock
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var task = DoWorkAsync();
            task.Wait();
            Console.WriteLine("After DoWorkAsync");
        }
        
        private static async Task DoWorkAsync()
        {
            Debug.WriteLine("Welcome");
            await Task.Delay(500);
            Debug.WriteLine("We are done");
        }
    }
}