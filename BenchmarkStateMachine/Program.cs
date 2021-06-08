using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace BenchmarkStateMachine
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<BenchmarkMe>();
        }
    }

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net472)]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class BenchmarkMe
    {
        private static readonly Task<string> ExampleTask = Task.FromResult("Hey dear DevExchange");

        [Benchmark]
        public async Task<string> GetStringWithoutAsync()
        {
            return await GetStringWithoutAsyncCore();
        }

        [Benchmark]
        public async Task<string> GetStringWithAsync()
        {
            return await GetStringWithAsyncCore();
        }
        
        public Task<string> GetStringWithoutAsyncCore()
        {
            return ExampleTask;
        }
        
        public async Task<string> GetStringWithAsyncCore()
        {
            return await ExampleTask;
        }
    }
}