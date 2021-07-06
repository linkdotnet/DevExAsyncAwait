using System;
using System.Threading.Tasks;

namespace Exceptions
{
    public static class Program
    {
        public static async Task Main()
        {
            try
            {
                // await DoWorkWithAwaitAsync();
                await DoWorkWithoutAwaitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static async Task DoWorkWithAwaitAsync()
        {
            await ThrowExceptionAsync();
        }

        private static Task DoWorkWithoutAwaitAsync()
        {
            return ThrowExceptionAsync();
        }

        private static async Task ThrowExceptionAsync()
        {
            await Task.Yield();
            throw new Exception("Hey");
        }
    }
}