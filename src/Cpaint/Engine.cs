using Cpaint.Commands;
using Cpaint.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static System.Console;

namespace Cpaint
{
    public class Engine
    {
        private readonly List<IFigure> _figures;


        private IFigure _selectedFigure;

        public IFigure SelectedFigure
        {
            get => _selectedFigure;
            set
            {
                if (value is null) _selectedFigure = null;
                else if (_figures.Contains(value)) _selectedFigure = value;
            }
        }
        public ConsoleColor ForeColor { get; private set; }
        private readonly Dictionary<char, Func<string, Engine, Task<bool>>> _commands;

        public IEnumerable<IFigure> Figures => _figures;

        public void RemoveFigure(IFigure figure) => _figures.Remove(figure);

        public Engine()
        {
            _commands = new Dictionary<char, Func<string, Engine, Task<bool>>>();
            FillCommands();
            _figures = new List<IFigure>();
            SelectedFigure = null;
            ForeColor = ConsoleColor.White;

            void FillCommands()
            {
                _commands.Add('d', BasicCommands.DrawCommand);
                _commands.Add('e', BasicCommands.EraseCommand);
                _commands.Add('a', BasicCommands.AreasCommand);
                _commands.Add('p', BasicCommands.NextColorCommand);
                _commands.Add('s', BasicCommands.SelectCommand);
                _commands.Add('c', BasicCommands.ClearCommand);
                _commands.Add('i', BasicCommands.InsertCommand);
                _commands.Add('m', BasicCommands.MoveCommand);
                _commands.Add('C', BasicCommands.AreaCountCommand);
            }
        }

        public async Task Run()
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
            Clear();
            var line = (string)null;
            var exit = false;
            while (!exit)
            {
                DrawStatus();
                line = ReadLine();
                BackgroundColor = ConsoleColor.Black;
                exit = await ProcessLine(line);
            }
        }


        private async Task<bool> ProcessLine(string line)
        {
            line = line.Trim();
            if (line.Length > 0)
            {
                char command = line[0];
                var handler = _commands.GetOrDefault(command);
                if (handler != default)
                {
                    await handler(line.Substring(1).Trim(), this);
                }
                else if (command == ':')
                {
                    return await ProcessExtendedCommand(line.Substring(1));
                }
            }

            return false;
        }

        public void RemoveFigureAt(int index) => _figures.RemoveAt(index);

        public IFigure GetFigureAt(int index) => _figures[index];



        private async Task<bool> ProcessExtendedCommand(string additionalcommands)
        {
            var ret = false;
            foreach (var cmd in additionalcommands)
            {
                switch (cmd)
                {
                    case 'w': await AdditionalCommands.Save(_figures); break;
                    case 'q': ret = true; break;
                }
            }

            return ret;
        }





        public void AddFigure(IFigure figure)
        {
            if (!_figures.Contains(figure)) _figures.Add(figure);
        }

        public void DrawInfo(string info)
        {
            DrawStatus(back: ConsoleColor.Green);
            Write(info);
            ReadKey();
        }


        public void DrawError(string err)
        {
            DrawStatus(back: ConsoleColor.Red);
            Write(err);
            ReadKey();
        }

        private static void DrawStatus(ConsoleColor fore = ConsoleColor.Black, ConsoleColor back = ConsoleColor.White)
        {
            var line = WindowHeight - 2;
            SetCursorPosition(0, line);
            BackgroundColor = back;
            ForegroundColor = fore;
            Write(new string(' ', WindowWidth));
            SetCursorPosition(0, line);
        }
    }
}
