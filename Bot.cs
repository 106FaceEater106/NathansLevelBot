using System;
using System.Threading;

namespace NathansLevelBot
{
    public class Bot
    {
        public void ManagedClick(Click click)
        {
            MouseOperations.SetCursorPosition(click.X, click.Y);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(10);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(click.Pause);
        }

        public void RandomClick()
        {
            Random rand = new Random();
            int x = rand.Next(300, 1600);
            int y = rand.Next(200, 800);
            int p = rand.Next(50, 2000);

            MouseOperations.SetCursorPosition(x, y);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(10);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(p);
        }
    }
}