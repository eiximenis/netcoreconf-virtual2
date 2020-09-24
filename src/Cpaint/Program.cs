using System;
using System.Threading.Tasks;

namespace Cpaint
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var engine = new Engine();
            await engine.Run();
        }
    }
}
