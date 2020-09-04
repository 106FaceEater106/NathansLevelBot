using System;
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
        public void RandomClick()
        {
            Random rand = new Random();
            int x = rand.Next(300, 1600);
            int y = rand.Next(200, 800);
            int p = rand.Next(50, 2000);
            int r = rand.Next(0, 10);

            Click(x, y, p);
            if (r == 5)
                UseAbility();
        }

        /// <summary>
        /// Centers the mouse and execute ability (F2, W, E)
        /// </summary>
        public void UseAbility()
        {
            int x = 1920 / 2;
            int y = 1080 / 2;
            int p = 200;

            Click(x, y, p);
            KeyOperations.PressCombo();
        }

        /// <summary>
        /// Simulates a specefic mouse click on the screen
        /// </summary>
        public void Click(int x, int y, int pause)
        {
            MouseOperations.SetCursorPosition(x, y);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(10);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(pause);
        }
    }
}