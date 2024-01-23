using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkCommercial.LostArkBot.Other
{
    public enum Grade
    {
        Normal=0,
        Uncommon=1,
        Rare=2,
        Epic=3,
        Legendary=4,
        Relic=5,
        Ancient=6,
        Ezdo=7,
    }
    public static class ColorGrade
    {
        public static DiscordColor Normal => new DiscordColor(255,255,255);
        public static DiscordColor Uncommon => new DiscordColor(141, 249, 1);
        public static DiscordColor Rare => new DiscordColor(0, 153, 217);//уточнить цвет
        public static DiscordColor Epic => new DiscordColor(206, 67, 252);
        public static DiscordColor Legendary => new DiscordColor(240, 140, 0);//уточнить цвет
        public static DiscordColor Relic => new DiscordColor(250, 93, 0);
        public static DiscordColor Ancient => new DiscordColor(227, 199, 161);
        public static DiscordColor Ezdo => new DiscordColor(60, 242, 230);
    }
}