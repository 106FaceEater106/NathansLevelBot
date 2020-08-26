using System;

namespace NathansLevelBot
{
    public class Click
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Pause { get; set; }

        public Click(int x, int y, int p)
        {
            this.X = x;
            this.Y = y;
            this.Pause = p;
        }
    }
}