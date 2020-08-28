using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace NathansLevelBot
{
    public class Import
    {
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

        public List<Button> GetButtons()
        {
            List<Button> buttons = new List<Button>();

            string buttonsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("Settings", "UsedButtons.json"));

            using (StreamReader r = new StreamReader(buttonsPath))
            {
                try
                {
                    string json = r.ReadToEnd();
                    List<int> rawButtonEntity = JsonConvert.DeserializeObject<List<int>>(json);

                    foreach (var item in rawButtonEntity)
                    {
                        Button button = (Button)item;
                        buttons.Add(button);
                    }
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Error while reading the Settings.json");
                }
            }
            return buttons;
        }
    }

    public enum Status
    {
        Initial = 0,
        Restart = 1
    }
}