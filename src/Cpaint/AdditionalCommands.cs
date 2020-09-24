using Cpaint.Figures;
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
            var fname = $"drawing_{Guid.NewGuid()}";
            dynamic data = JArray.FromObject(figures);
            var idx = 0;
            foreach (dynamic item in data)
            {
                item.type = types[idx++];
            }

            await File.WriteAllTextAsync(fname, data.ToString());
        }

        public static void ListAdds(string command, ReadOnlySpan<FigureAddedOperation> span, Engine engine)
        {
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var (from, _) = tokens.GetTokenAt(position: 0);
            var (to, _) = tokens.GetTokenAt(position: 1, span.Length );
            var entries = span[from..to];
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var entry in entries)
            {
                DumpEntry(in entry);
            }

            engine.DrawInfo("+++ PRESS ANY KEY");
            Console.ReadKey();

            static void DumpEntry(in FigureAddedOperation entry)
            {
                var str = entry.Figure switch
                {
                    Square s when s.Area() <= 16.0 => $"Small Square of area {s.Area()}",
                    Square s when s.Area() > 16.0 && s.Area() <= 64.0 => $"Medium square of area {s.Area()}",
                    Square s => $"Big square of area ${s.Area()}",
                    Text t when t.Content.Length < 4 => $"Short text: {t.Content}",
                    Text t when t.Content.Length >= 4 && t.Content.Length < 10 => $"Medium text: {t.Content}",
                    Text t => $"Large text: {t.Content}",
                    _ => "Unknown figure"
                };

                Console.WriteLine(str);

            }            

        }
    }
}
