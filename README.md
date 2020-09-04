![.NET Core](https://github.com/Facing-South/NathansLevelBot/workflows/.NET%20Core/badge.svg)

# Nathan's Level-Bot by Facing-South

This bot opens League of Legends and starts a match. Then he moves the champion randomly across the map so that you can gain experience and level up without having to play yourself. When a round is over, it automatically starts the next round. This process repeats itself until you turn off the bot.

## Installation

In order to be able to guarantee the correct functioning of the bot, 3 files must be adapted. These are located in the "Settings" folder and have the following names:

- StartGame.json
- UsedButtons.json
- RestartGame.json

### StartGame.json

This file simulates the 9 clicks it takes to open League of Legends via the icon on the desktop and actively start a round.

```json
[
  { "Position": "Icon", "X": 660, "Y": 880, "Word": null, "Pause": 1000 },
  { "Position": "Play", "X": 320, "Y": 150, "Word": null, "Pause": 1000 },
  { "Position": "Coop", "X": 380, "Y": 200, "Word": null, "Pause": 1000 },
  {
    "Position": "Intermediate",
    "X": 600,
    "Y": 570,
    "Word": null,
    "Pause": 1000
  },
  { "Position": "Confirm", "X": 650, "Y": 680, "Word": null, "Pause": 2000 },
  { "Position": "FindMatch", "X": 650, "Y": 680, "Word": null, "Pause": 7000 },
  { "Position": "Accept", "X": 750, "Y": 550, "Word": null, "Pause": 10000 },
  {
    "Position": "Champion",
    "X": 1600,
    "Y": 100,
    "Word": "Yuumi",
    "Pause": 500
  },
  { "Position": "Confirm", "X": 750, "Y": 600, "Word": null, "Pause": 10000 }
]
```

To explain what the individual entries mean, let's take a look at the first line: Here the League of Legends icon should be clicked. For this the icon at the beginning of this line. The next two entries X & Y are the coordinates of the icon on the screen. The origin of coordinates is in the upper left corner of monitors. The horizontal axis is X and the vertical axis is Y. If the icon is e.g. vertically in the middle and horizontally on the far right of the screen would be the coordinates X: 1090 and Y: 540 (if you are using a screen with 1920X1080 resolution). At this point you have to enter where your League of Legend icon is on the screen.Now you have to indicate after "Word" whether a word or letter should be entered after the click has been completed. This makes e.g. then it makes sense if you click on the search field when choosing a champion and then want to enter a name for the champion. Last but not least, a value must be entered for pause. This value indicates how many milliseconds the bot should wait after clicking on the coordinates you gave it. So it takes e.g. one to two minutes after clicking the icon, until the launcher starts and the next click has to be performed. You have to adapt that to your system. As soon as you have adjusted all entries in this StartGame.json save the changes.

### UsedButtons.json

This file contains the values which keyboard keys should be pressed while ingame. The order in which the buttons are pressed is the same as the order in the UsedButtons.json. In the following example the keys F2, W, E are pressed one after the other. The frequency with which this sequence is carried out varies between approx. 5 and 25 seconds.

```json
["F2", "W", "E"]
```

To influence which keys should be pressed one after the other, the UsedButtons.json can simply be edited. The possible entries are all letters, as well as F1 and F2.

### RestartGame.json

This file contains the clicks that the bot should make after a round has ended. The structure for clicking the corresponding buttons is the same as the structure for starting the bot for the first time. Adjust the coordinates and the break times as you like so that the bot can start the next round by itself. If you have set everything correctly, the bot should ensure that League of Legends is opened and a round is started. Since you are in one round, your champion should run through the area by itself and use the skills that are on the keys that you have specified in the Buttons.json. When a round ends, it starts the next round by itself. This cycle continues until you turn off the bot.

## Starting

Once all settings out of the installation-part are done, you dont have to edit them anymore if you wont move your icon on the desktop anymore. If you do it, just fit the correct values of the positions inside the StartGame.json or RestartGame.json.

## Contributions

I cordially invite you all to expand and improve this bot with me. Simply fork the repository, make your changes, and submit a pull request. We can then look at it together. If you have any questions or criticism, you can also contact me via my homepage. There you will find a link to my Discord server.

## Known Issues

- So far, the bot has only been tested on a system to which only one monitor with a resolution of 1920X1080 is connected. It cannot yet be guaranteed that the bot will work with a multi-monitor system.
