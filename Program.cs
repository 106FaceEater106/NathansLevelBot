using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace NathansLevelBot
{
    /// <summary>
    /// Nathan's Level-Bot
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Initialize the bot
            Bot bot = new Bot();

            // Initialize the import
            Import import = new Import();

            // Get a list of all commands for the startup
            List<Click> initialClicks = import.GetClicks(Status.Initial);

            // Get a list of all buttons-commands for the game
            List<string> usedButtons = import.GetButtons();

            // Get a list of all commands for the restart of a game
            List<Click> restartClicks = import.GetClicks(Status.Restart);

            // Execute the commands for the startup
            initialClicks.ForEach(item => bot.ManagedClick(item));

            // Execute random behavior in the game
            while (true)
                bot.RandomBehavior(usedButtons);
        }
    }
}