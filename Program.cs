using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace NathansLevelBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            Import import = new Import();

            List<Click> initialClicks = import.GetClicks(Status.Initial);
            List<Button> usedButtons = import.GetButtons();
            List<Click> restartClicks = import.GetClicks(Status.Restart);

            initialClicks.ForEach(item => bot.ManagedClick(item));

            while (true)
                bot.RandomClick();
        }
    }
}