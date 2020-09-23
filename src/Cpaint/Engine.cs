using Cpaint.Figures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    public class Engine
    {
        private readonly FigureCollection _figures;
        private IFigure _selectedFigure;
        private ConsoleColor _foreColor;

        public Engine()
        {
            _figures = new FigureCollection();
            _selectedFigure = null;
            _foreColor = ConsoleColor.White;
        }

        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            string line = null;
            while (true)
            {
                DrawStatus(ConsoleColor.Black, ConsoleColor.White);
                line = Console.ReadLine();
                Console.BackgroundColor = ConsoleColor.Black;
                ProcessLine(line);
            }
        }

        private void ProcessLine(string line)
        {
            line = line.Trim();
            if (line.Length > 0)
            {
                char command = line[0];
                switch (command)
                {
                    case 'd': ProcessDrawCommand(); break;
                    case 'e': ProcessEraseCommand(); break;
                    case 'a': ProcessAreasCommand(); break;
                    case 's': ProcessSelectCommand(line.Substring(1)); break;
                    case 'c': ProcessClearCommand(line.Substring(1)); break;
                    case 'i': ProcessInsertCommand(line.Substring(1)); break;
                    case 'm': ProcessMoveCommand(line.Substring(1)); break;
                }
            }
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
                string top = tokens[1];
                string left = tokens[2];
                string rows = tokens[3];
                string cols = tokens[4];
                Square sq = new Square(new CPoint(int.Parse(left), int.Parse(top)), int.Parse(rows), int.Parse(cols));
                _figures.Add(sq);
                sq.SetForeground(_foreColor);
                ProcessDrawCommand();
            }
        }

        private void CreateText(string[] tokens)
        {
            if (tokens.Length > 3)
            {
                string top = tokens[1];
                string left = tokens[2];
                string text = tokens[3];
                Text tx = new Text(new CPoint(int.Parse(left), int.Parse(top)), text);
                tx.SetForeground(_foreColor);
                _figures.Add(tx);
                ProcessDrawCommand();
            }
        }

        private void ProcessClearCommand(string command)
        {
            command = command.Trim();
            int index = -1;
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
            int index = -1;
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
            double area = 0.0;
            double min = double.MinValue;
            double max = 0.0;
            double avg = 0.0;

            foreach (IFigure figure in _figures)
            {
                double farea = figure.Area();
                area += farea;
                if (min < farea) min = farea;
                if (farea > max) max = farea;
            }

            avg = area / _figures.Count;

            DrawInfo(string.Format("Total {0}, Min {1}, Max {2}, Avg {3} (Count {4})", area, min, max, avg, _figures.Count));
        }

        private void DrawInfo(string info)
        {
            DrawStatus(ConsoleColor.Black, ConsoleColor.Green);
            Console.Write(info);
            Console.ReadKey();
        }


        private void DrawError(string err)
        {
            DrawStatus(ConsoleColor.Black, ConsoleColor.Red);
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
            foreach (IFigure figure in _figures)
            {
                figure.Draw();
            }
        }



        private static void DrawStatus(ConsoleColor fore, ConsoleColor back)
        {
            int line = Console.WindowHeight - 1;
            Console.SetCursorPosition(0, line);
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line);
        }
    }
}
