using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AwaitTaskVsAwaitFunctionRuntime
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            await AwaitDirectly();
            Console.WriteLine($"AwaitDirectly took {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            await AwaitOneByOne();
            Console.WriteLine($"AwaitOneByOne took {stopwatch.ElapsedMilliseconds} ms");
        }

        private static async Task AwaitDirectly()
        {
            await Task.Delay(1000);
            await Task.Delay(1000);
            await Task.Delay(1000);
            await Task.Delay(1000);
            await Task.Delay(1000);
        }

        private static async Task AwaitOneByOne()
        {
            var a = Task.Delay(1000);
            var b = Task.Delay(1000);
            var c = Task.Delay(1000);
            var d = Task.Delay(1000);
            var e = Task.Delay(1000);

            await a;
            await b;
            await c;
            await d;
            await e;
        }
    }
}
