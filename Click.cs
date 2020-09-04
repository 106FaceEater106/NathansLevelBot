using System;

namespace NathansLevelBot
{
    /// <summary>
    /// Entity of a mouse click
    /// </summary>
    public class Click
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Pause { get; set; }
        public string Word { get; set; }

        public Click(int x, int y, string word, int p)
        {
            this.X = x;
            this.Y = y;
            this.Word = word;
            this.Pause = p;
        }
    }
}