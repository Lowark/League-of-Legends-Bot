﻿using LeagueBot.Api;
using LeagueBot.ApiHelpers;
using LeagueBot.Image;
using LeagueBot.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeagueBot.Game.Entities
{
    public class MainPlayer : ApiMember<GameApi>
    {
        public MainPlayer(GameApi api) : base(api)
        {

        }

        public bool dead()
        {
            return LCU.IsPlayerDead();
        }
        public void castSpell(int indice, int x, int y)
        {
            string key = "D" + indice;
            InputHelper.MoveMouse(x, y);
            InputHelper.PressKey(key);
            BotHelper.InputIdle();
        }
     
        public void upgradeSpell(int indice)
        {
            Point coords = new Point();

            switch (indice)
            {
                case 1:
                    coords = new Point(826, 833);
                    break;
                case 2:
                    coords = new Point(875, 833);
                    break;
                case 3:
                    coords = new Point(917, 833);
                    break;
                case 4:
                    coords = new Point(967, 833);
                    break;
                default:
                    Logger.Write("Unknown spell indice :" + indice, MessageState.WARNING);
                    return;
            }

            InputHelper.LeftClick(coords.X, coords.Y);
            BotHelper.InputIdle();
        }
        public int getLevel()
        {
            return LCU.GetPlayerLevel();
        }
        public string getName()
        {
            return LCU.GetPlayerName();
        }
        public void upgradeSpellOnLevelUp()
        {
            int level = getLevel();

            switch (level)
            {
                case 1:
                    upgradeSpell(1); // Q 1
                    break;
                case 2:
                    upgradeSpell(2); // W 1
                    break;
                case 3:
                    upgradeSpell(3); // E 1
                    break;
                case 4:
                    upgradeSpell(1); // Q 2
                    break;
                case 5:
                    upgradeSpell(1); // Q 3
                    break;
                case 6:
                    upgradeSpell(4); // R 1
                    break;
                case 7:
                    upgradeSpell(1); // Q 4
                    break;
                case 8:
                    upgradeSpell(3); // E 2
                    break;
                case 9:
                    upgradeSpell(1); // Q max
                    break;
                case 10:
                    upgradeSpell(3); // E 3
                    break;
                case 11:
                    upgradeSpell(4); // R 2
                    break;
                case 12:
                    upgradeSpell(3); // E 4
                    break;
                case 13:
                    upgradeSpell(3); // E max
                    break;
                case 14:
                    upgradeSpell(2); // W 2
                    break;
                case 15:
                    upgradeSpell(2); // W 3
                    break;
                case 16:
                    upgradeSpell(4); // R max
                    break;
                case 17:
                    upgradeSpell(2); // W 4
                    break;
                case 18:
                    upgradeSpell(2); // W max
                    break;
                default:
                    //something not leveled?
                    upgradeSpell(1);
                    upgradeSpell(2);
                    upgradeSpell(3);
                    upgradeSpell(4);
                    break;
            }
        }
     
        public bool getCharacterLeveled()
        {
            return TextHelper.TextExists(835, 772, 81, 27, "level up");
        }

        public int getHealthPercent()
        {
            int value = ImageValues.Health();
            //BotHelper.Log("Health is " + value);
            return value;
        }
        public int getManaPercent()
        {
            int value = ImageValues.Mana();
            //BotHelper.Log("Mana is " + value);
            return value;
        }

     
        public int gameMinute()
        {
            int minute = TextHelper.GetTextFromImage(1426, 171, 16, 16);
            BotHelper.Log("Game is on minute " + minute.ToString());
            return minute;
        }
    }
}
