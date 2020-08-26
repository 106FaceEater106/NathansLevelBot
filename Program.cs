using System;
using System.Threading;

namespace NathansLevelBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MouseOperations.SetCursorPosition(10, 1050);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            Thread.Sleep(2500);
        }
    }
}