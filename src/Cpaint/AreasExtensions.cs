using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    static class AreasExtensions
    {
        public static (double total, double avg, int count) CalculateStatistics(this IEnumerable<double> areas) => (areas.Sum(), areas.Average(), areas.Count());
    }
}
