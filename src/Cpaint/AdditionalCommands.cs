using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    static class AdditionalCommands
    {

        public static async Task Save(IEnumerable<IFigure> figures)
        {
            var types = figures.Select(f => f.GetType().Name).ToArray();
            var fname = "drawing_" + Guid.NewGuid().ToString("d");
            dynamic data = JArray.FromObject(figures);
            var idx = 0;
            foreach (dynamic item in data)
            {
                item.type = types[idx++];
            }

            await File.WriteAllTextAsync(fname, data.ToString());
        }

    }
}
