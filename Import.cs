using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            if (status == Status.Initial)
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("Settings", "StartGame.json"));
            else if (status == Status.Restart)
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("Settings", "RestartGame.json"));

            using (StreamReader r = new StreamReader(path))
            {
                try
                {
                    string json = r.ReadToEnd();
                    List<Click> rawClickEntity = JsonConvert.DeserializeObject<List<Click>>(json);
                    clicks = rawClickEntity.Select(item => new Click(item.X, item.Y, item.Word, item.Pause)).ToList();
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Error while reading the Settings.json");
                }
            }
            return clicks;
        }

        /// <summary>
        /// Converts the UsedButtons.json into C# entities and returns a List of them.
        /// </summary>
        public List<string> GetButtons()
        {
            List<string> buttons = new List<string>();

            string buttonsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("Settings", "UsedButtons.json"));

            using (StreamReader r = new StreamReader(buttonsPath))
            {
                try
                {
                    string json = r.ReadToEnd();
                    List<string> rawButtonEntity = JsonConvert.DeserializeObject<List<string>>(json);
                    rawButtonEntity.ForEach(item => buttons.Add(item));
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Error while reading the Settings.json");
                }
            }
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