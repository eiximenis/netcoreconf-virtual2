using Cpaint.Figures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    public class Engine
    {
        private readonly List<IFigure> _figures;
        private IFigure _selectedFigure;
        private ConsoleColor _foreColor;

        public Engine()
        {
            _figures = new List<IFigure>();
            _selectedFigure = null;
            _foreColor = ConsoleColor.White;
        }

        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            var line = (string)null;
            var exit = false;
            while (!exit)
            {
                DrawStatus();
                line = Console.ReadLine();
                Console.BackgroundColor = ConsoleColor.Black;
                exit = ProcessLine(line);
            }
        }

        private bool ProcessLine(string line)
        {
            line = line.Trim();
            if (line.Length > 0)
            {
                char command = line[0];
                switch (command)
                {
                    case 'd': ProcessDrawCommand(); return false;
                    case 'e': ProcessEraseCommand(); return false;
                    case 'a': ProcessAreasCommand(); return false;
                    case 'p': ProcessNextColorCommand(); return false;
                    case 's': ProcessSelectCommand(line.Substring(1)); return false;
                    case 'c': ProcessClearCommand(line.Substring(1)); return false;
                    case 'i': ProcessInsertCommand(line.Substring(1)); return false;
                    case 'm': ProcessMoveCommand(line.Substring(1)); return false;
                    case ':': return ProcessExtendedCommand(line.Substring(1));
                }
            }

            return false;
        }

        private bool ProcessExtendedCommand(string additionalcommands)
        {
            var ret = false;
            foreach (var cmd in additionalcommands)
            {
                switch (cmd)
                {
                    case 'w': AdditionalCommands.Save(_figures); break;
                    case 'q': ret = true; break;
                }
            }

            return ret;
        }

        private void ProcessNextColorCommand()
        {
            if (_selectedFigure == null) return;
            _selectedFigure.SetNextColor();
            _selectedFigure.Draw();
        }

        private void ProcessMoveCommand(string command)
        {
            if (_selectedFigure == null) return;
            string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            _selectedFigure.MoveTo(new CPoint(int.Parse(tokens[0]), int.Parse(tokens[1])));
            ProcessDrawCommand();

        }

        private void ProcessInsertCommand(string command)
        {
            string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "s": CreateSquare(tokens); break;
                case "t": CreateText(tokens); break;
            }
        }

        private void CreateSquare(string[] tokens)
        {
            if (tokens.Length > 4)
            {
                var top = tokens[1];
                var left = tokens[2];
                var rows = tokens[3];
                var cols = tokens[4];
                var sq = new Square(new CPoint(x: int.Parse(left), y: int.Parse(top)), rows: int.Parse(rows), cols: int.Parse(cols));
                _figures.Add(sq);
                sq.SetForeground(_foreColor);
                ProcessDrawCommand();
            }
        }

        private void CreateText(string[] tokens)
        {
            if (tokens.Length > 3)
            {
                var top = tokens[1];
                var left = tokens[2];
                var text = tokens[3];
                var tx = new Text(new CPoint(x: int.Parse(left), y: int.Parse(top)), text);
                tx.SetForeground(_foreColor);
                _figures.Add(tx);
                ProcessDrawCommand();
            }
        }

        private void ProcessClearCommand(string command)
        {
            command = command.Trim();
            var index = -1;
            if (int.TryParse(command, out index))
            {
                if (index < _figures.Count)
                {
                    _figures.RemoveAt(index);
                    ProcessDrawCommand();
                }
            }
            else
            {
                DrawError("ERROR");
            }
        }

        private void ProcessSelectCommand(string command)
        {
            command = command.Trim();
            var index = -1;
            if (int.TryParse(command, out index))
            {
                if (index < _figures.Count)
                {
                    if (_selectedFigure != null)
                    {
                        _selectedFigure.SetForeground(_foreColor);
                    }
                    _selectedFigure = _figures[index];
                    _selectedFigure.SetForeground(ConsoleColor.Blue);
                }
            }
            else
            {
                DrawError("ERROR");
            }
        }

        private void ProcessAreasCommand()
        {
            var min = _figures.Min(f => f.Area() ?? double.MaxValue);
            var max = _figures.Max(f => f.Area() ?? 0.0);
            var areas = _figures
                .Select(f => f.Area())
                .Where(x => x.HasValue)
                .Select(x => x.Value);

            var area = areas.Sum();
            var avg = areas.Average();
            var count = areas.Count();

            DrawInfo(string.Format("Total {0}, Min {1}, Max {2}, Avg {3} (Count {4})", area, min, max, avg, count));
        }

        private void DrawInfo(string info)
        {
            DrawStatus(back: ConsoleColor.Green);
            Console.Write(info);
            Console.ReadKey();
        }


        private void DrawError(string err)
        {
            DrawStatus(back: ConsoleColor.Red);
            Console.Write(err);
            Console.ReadKey();
        }

        private void ProcessEraseCommand()
        {
            if (_selectedFigure != null)
            {
                _figures.Remove(_selectedFigure);
                _selectedFigure = null;
                ProcessDrawCommand();
            }
            else
            {
                DrawError("NO FIGURE SELECTED");
            }
        }

        private void ProcessDrawCommand()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            foreach (var figure in _figures)
            {
                figure.Draw();
            }
        }



        private static void DrawStatus(ConsoleColor fore = ConsoleColor.Black, ConsoleColor back = ConsoleColor.White)
        {
            var line = Console.WindowHeight - 2;
            Console.SetCursorPosition(0, line);
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line);
        }
    }
}
