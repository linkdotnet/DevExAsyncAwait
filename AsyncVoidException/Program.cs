using System;
using System.Threading.Tasks;

namespace AsyncVoidException
{
    public static class Program
    {
        public static async Task Main()
        {
            try
            {
                await ThrowExceptionAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("We are inside the catch block");
                Console.WriteLine(e);
                throw;
            }

            Console.Write("Was there something?");
        }

        private static async void ThrowExceptionAsync()
        {
            await Task.Yield();
            throw new Exception("This is our small happy accident");
        }
    }
}