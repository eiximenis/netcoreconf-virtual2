using Cpaint.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Cpaint.Commands
{
    public static class BasicCommands
    {
        public static Task<bool> DrawCommand(string command, Engine engine)
        {
            BackgroundColor = ConsoleColor.Black;
            Clear();
            foreach (var figure in engine.Figures)
            {
                figure.Draw();
            }

            return Task.FromResult(false);
        }

        public async static Task<bool> EraseCommand(string command, Engine engine)
        {
            if (engine.SelectedFigure != null)
            {
                engine.RemoveFigure(engine.SelectedFigure);
                engine.SelectedFigure = null;
                return await DrawCommand("", engine);
            }
            else
            {
                engine.DrawError("NO FIGURE SELECTED");
                return false;
            }
        }

        public static Task<bool> AreasCommand(string command, Engine engine)
        {
            var min = engine.Figures.Min(f => f.Area() ?? double.MaxValue);
            var max = engine.Figures.Max(f => f.Area() ?? 0.0);
            var areas = engine.Figures
                .Select(f => f.Area())
                .Where(x => x.HasValue)
                .Select(x => x.Value);

            var (area, avg, count) = areas.CalculateStatistics();
            engine.DrawInfo($"Total {area}, Min {min}, Max {max}, Avg {avg} (Count {count})");

            return Task.FromResult(false);
        }

        public static Task<bool> NextColorCommand(string command, Engine engine)
        {
            engine.SelectedFigure?.SetNextColor();
            engine.SelectedFigure?.Draw();
            return Task.FromResult(false);
        }

        public static Task<bool> SelectCommand(string command, Engine engine)
        {
            if (int.TryParse(command, out var index) && index < engine.Figures.Count())
            {
                engine.SelectedFigure?.SetForeground(engine.ForeColor);
                engine.SelectedFigure = engine.GetFigureAt(index);
                engine.SelectedFigure.SetForeground(ConsoleColor.Blue);
            }
            else
            {
                engine.DrawError("ERROR");
            }

            return Task.FromResult(false);
        }

        public async static Task<bool> ClearCommand(string command, Engine engine)
        {
            if (int.TryParse(command, out var index) && index < engine.Figures.Count())
            {
                engine.RemoveFigureAt(index);
                return await DrawCommand("", engine);
            }
            else
            {
                engine.DrawError("ERROR");
                return false;
            }
        }

        public static async Task<bool> InsertCommand(string command, Engine engine)
        {
            string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                switch (tokens[0])
                {
                    case "s": await CreateSquare(); break;
                    case "t": await CreateText(); break;
                }
                return false;
            }
            catch (ArgumentException ex)
            {
                engine.DrawError(ex.Message);
                return false;
            }

            async Task CreateSquare()
            {
                if (tokens.Length > 4)
                {
                    if (int.TryParse(tokens[1], out var top) &&
                        int.TryParse(tokens[2], out var left) &&
                        int.TryParse(tokens[3], out var rows) &&
                        int.TryParse(tokens[4], out var cols))
                    {
                        var sq = new Square(new CPoint(x: left, y: top), rows: rows, cols: cols);
                        engine.AddFigure(sq);
                        sq.SetForeground(engine.ForeColor);
                        await DrawCommand("", engine);
                    }
                }
            }

            async Task CreateText()
            {
                if (tokens.Length > 3)
                {
                    if (int.TryParse(tokens[1], out var top) &&
                        int.TryParse(tokens[2], out var left))
                    {
                        var text = tokens[3];
                        var tx = new Text(new CPoint(x: left, y: top), text);
                        tx.SetForeground(engine.ForeColor);
                        engine.AddFigure(tx);
                        await DrawCommand("", engine);
                    }
                }
            }
        }

        public static async Task<bool> MoveCommand(string command, Engine engine)
        {
            if (engine.SelectedFigure == null) return false;
            string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            engine.SelectedFigure.MoveTo(new CPoint(int.Parse(tokens[0]), int.Parse(tokens[1])));
            return await DrawCommand("", engine);
        }

        public static Task<bool> AreaCountCommand(string command, Engine engine)
        {
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 1) return Task.FromResult(false);

            if (double.TryParse(tokens[0], out var minArea))
            {
                var areas = engine.Figures.Select(f => f.Area());
                var nulls = 0;
                var less = 0;
                var more = 0;
                var equals = 0;
                foreach (var area in areas)
                {
                    switch (area)
                    {
                        case null: nulls++; break;
                        case double a when a > minArea: more++; break;
                        case double a when a < minArea: less++; break;
                        case double a when a == minArea: equals++; break;
                    }
                }
                engine.DrawInfo($"Requested Area: {minArea}. Less: {less}, More: {more}, Eq: {equals} (nulls: {nulls})");
                return Task.FromResult(false);
            }
            else
            {
                engine.DrawError("ERROR");
                return Task.FromResult(false);
            }
        }

    }
}
