using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;

namespace SyncDeadlock.Controllers
{
    [Route("deadlock")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            Debug.WriteLine("Before DoWorkAsync");
            var task = DoWorkAsync();
            task.Wait();
            Debug.WriteLine("After DoWorkAsync");

            return new string[] { "value1", "value2" };
        }

        private async Task DoWorkAsync()
        {
            Debug.WriteLine("Welcome");
            await Task.Delay(500);
            Debug.WriteLine("We are done");
        }
    }
}
