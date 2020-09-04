using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NathansLevelBot
{
    /// <summary>
    /// Import class which converts the StartGame.json, UsedButtons.json and RestartGame.json into C# entities.
    /// </summary>
    public class Import
    {
        /// <summary>
        /// Converts the StartGame.json and RestartGame.json into C# entities and returns a List of them.
        /// </summary>
        public List<Click> GetClicks(Status status)
        {
            List<Click> clicks = new List<Click>();
            string path = string.Empty;

            switch (status)
            {
                case Status.Initial:
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("Settings", "StartGame.json"));
                    Program.PrintInfo($"Path to \"StartGame.json\": {path}", Message.Debug);
                    break;
                case Status.Restart:
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("Settings", "RestartGame.json"));
                    Program.PrintInfo($"Path to \"RestartGame.json\": {path}", Message.Debug);
                    break;
                default:
                    break;
            }

            Program.PrintInfo($"Open StreamReader to {path}", Message.Debug);

            using (StreamReader r = new StreamReader(path))
            {
                try
                {
                    string json = r.ReadToEnd();
                    List<Click> rawClickEntity = JsonConvert.DeserializeObject<List<Click>>(json);
                    clicks = rawClickEntity.Select(item => new Click(item.X, item.Y, item.Word, item.Pause)).ToList();
                }
                catch
                {
                    Program.PrintInfo($"Error while reading {path}", Message.Error);
                }
            }

            Program.PrintInfo($"Close StreamReader to {path}", Message.Debug);
            return clicks;
        }

        /// <summary>
        /// Converts the UsedButtons.json into C# entities and returns a List of them.
        /// </summary>
        public List<string> GetButtons()
        {
            List<string> buttons = new List<string>();

            string buttonsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("Settings", "UsedButtons.json"));

            Program.PrintInfo($"Path to \"UsedButtons.json\": {buttonsPath}", Message.Debug);

            Program.PrintInfo($"Open StreamReader to {buttonsPath}", Message.Debug);

            using (StreamReader r = new StreamReader(buttonsPath))
            {
                try
                {
                    string json = r.ReadToEnd();
                    List<string> rawButtonEntity = JsonConvert.DeserializeObject<List<string>>(json);
                    rawButtonEntity.ForEach(item => buttons.Add(item));
                    buttons.ForEach(item => Program.PrintInfo("Key {item} imported", Message.Debug));
                }
                catch (System.Exception)
                {
                    Program.PrintInfo($"Error while reading {buttonsPath}", Message.Error);
                }
            }

            Program.PrintInfo($"Close StreamReader to {buttonsPath}", Message.Debug);
            return buttons;
        }
    }

    /// <summary>
    /// Helper-Type for "GetClicks"-Methode.
    /// </summary>
    public enum Status
    {
        Initial = 0,
        Restart = 1
    }
}