using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Figgle;
using Newtonsoft.Json;

namespace NathansLevelBot
{
    /// <summary>
    /// Nathan's Level-Bot
    /// </summary>
    public class Program
    {
        // Defines if debug messages should be post to the console
        static bool _postDebugMessage = false;

        static void Main(string[] args)
        {
            // Set the default foreground color of the console
            Console.ForegroundColor = ConsoleColor.Green;

            //Print Headline
            Headline();

            // Initialize the bot
            PrintInfo("Initializing Nathan's Level-Bot", Message.Info);
            Bot bot = new Bot();

            // Initialize the import
            PrintInfo("Initializing import", Message.Info);
            Import import = new Import();

            // Get a list of all commands for the startup
            PrintInfo("Import of the \"StartGame.json\" commands", Message.Info);
            List<Click> initialClicks = import.GetClicks(Status.Initial);

            PrintInfo("Import of the \"UsedButtons.json\" commands", Message.Info);
            // Get a list of all buttons-commands for the game
            List<string> usedButtons = import.GetButtons();

            PrintInfo("Import of the \"RestartGame.json\" commands", Message.Info);
            // Get a list of all commands for the restart of a game
            List<Click> restartClicks = import.GetClicks(Status.Restart);

            PrintInfo("Executing commands out of \"StartGame.json\"", Message.Info);
            // Execute the commands for the startup
            initialClicks.ForEach(item => bot.ManagedClick(item));

            PrintInfo("Executing random behavior", Message.Info);
            // Execute random behavior in the game
            while (true)
                bot.RandomBehavior(usedButtons);
        }

        public static void PrintInfo(string info, Message message)
        {
            bool isDebugMessage = message == Message.Debug ? true : false;

            StringBuilder sb = new StringBuilder();
            string timeStamp = DateTime.Now.ToString();

            switch (message)
            {
                case Message.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Message.Debug:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Message.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }

            sb.Append($"[{timeStamp}] ");
            sb.Append(info);
            sb.Append("...");

            if (!isDebugMessage)
                System.Console.WriteLine(sb.ToString());
            else if (isDebugMessage && _postDebugMessage)
                System.Console.WriteLine(sb.ToString());
        }

        private static void Headline()
        {
            Console.WriteLine(
                FiggleFonts.Slant.Render("Nathan's Level-Bot"));
            Console.WriteLine(
                FiggleFonts.Slant.Render("by Facing-South"));
            System.Console.WriteLine("                                  ##### Version 1.0.3 #####");

            System.Console.WriteLine(Environment.NewLine);
            System.Console.WriteLine(Environment.NewLine);
            Thread.Sleep(2500);

        }

    }

    public enum Message
    {
        Info = 0,
        Debug = 1,
        Error = 2
    }
}
