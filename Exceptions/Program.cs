using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exceptions
{
    public static class Program
    {
        public static async Task Main()
        {
            var ids = new List<int>();
            ids.ForEach(async id => await Task.Delay(id));
            
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