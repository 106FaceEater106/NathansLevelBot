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

            if (click.Word != null)
                KeyOperations.PressKey(click.Word);

            Thread.Sleep(click.Pause);
        }

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

        public void UseAbility()
        {
            int x = 1920 / 2;
            int y = 1080 / 2;
            int p = 200;

            Click(x, y, p);
            KeyOperations.PressCombo();
        }

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