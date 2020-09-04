using System;
using System.Collections.Generic;
using System.Threading;

namespace NathansLevelBot
{
    /// <summary>
    /// Main-Class of Nathan's Level-Bot bot where the abilities come together
    /// </summary>
    public class Bot
    {
        /// <summary>
        /// Executes the commands out of the StartGame.json and RestartGame.json
        /// It simulates a mouse click on a specefic position, write a word or
        /// letter if necessary and wait the entered time to execute the following
        /// command out of the json-files.
        /// </summary>
        public void ManagedClick(Click click)
        {
            Program.PrintInfo($"Executing managed click => Name:{click.Name} X:{click.X}, Y:{click.Y} and wait {click.Pause} milliseconds", Message.Info);
            MouseOperations.SetCursorPosition(click.X, click.Y);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(10);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);

            if (click.Word != null)
                KeyOperations.PressKey(click.Word);

            Thread.Sleep(click.Pause);
        }

        /// <summary>
        /// Simulates a random mouse click on the screen
        /// </summary>
        public void RandomBehavior(List<string> buttons)
        {
            Program.PrintInfo("Generating random coordinates and pause times for a click", Message.Info);
            Random rand = new Random();
            int x = rand.Next(300, 1600);
            int y = rand.Next(200, 800);
            int p = rand.Next(100, 2000);
            int r = rand.Next(0, 10);

            Click(x, y, p);
            if (r == 5)
                UseAbility(buttons);
        }

        /// <summary>
        /// Centers the mouse and execute ability (F2, W, E)
        /// </summary>
        public void UseAbility(List<string> buttons)
        {
            Program.PrintInfo("Center click to prepate keyboard entries", Message.Info);

            int x = 1920 / 2;
            int y = 1080 / 2;
            int p = 200;

            Click(x, y, p);

            Program.PrintInfo("Pressing keys of \"UsedButtons.Json\"", Message.Info);
            buttons.ForEach(item => KeyOperations.PressKey(item));
        }

        /// <summary>
        /// Simulates a specefic mouse click on the screen
        /// </summary>
        public void Click(int x, int y, int pause)
        {
            Program.PrintInfo($"Executing click => Name:Random, X:{x}, Y:{y} and wait {pause} milliseconds", Message.Info);
            MouseOperations.SetCursorPosition(x, y);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(10);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(pause);
        }
    }
}