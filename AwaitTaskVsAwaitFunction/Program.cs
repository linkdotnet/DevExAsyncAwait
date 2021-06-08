using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitTaskVsAwaitFunction
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await DoSomeWorkAsync();
            Console.WriteLine("Some independent stuff on ThreadId: " + Thread.CurrentThread.ManagedThreadId);

            var task = DoSomeWorkAsync();
            Console.WriteLine("Some independent stuff on ThreadId: " + Thread.CurrentThread.ManagedThreadId);
            await task;
        }

        public static async Task DoSomeWorkAsync()
        {
            Console.WriteLine("Begin DoSomeWorkAsync with ThreadId: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(100); // Let's check the thread ID
            Console.WriteLine("End DoSomeWorkAsync with ThreadId: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}