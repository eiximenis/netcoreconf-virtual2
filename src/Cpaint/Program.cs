using System;
using System.Threading.Tasks;

namespace Cpaint
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run().Wait();
        }
    }
}
