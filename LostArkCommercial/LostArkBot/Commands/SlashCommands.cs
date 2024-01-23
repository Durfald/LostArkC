using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using LostArkCommercial.LostArkBot.Database;
using LostArkCommercial.LostArkBot.Database.Models;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkCommercial.LostArkBot.Commands
{
    internal class SlashCommands : ApplicationCommandModule
    {

        //[SlashCommand("Create-Team", "creates a team")]
        //[Option("Team_name", "name of your team")]
        [SlashCommand("Get-Info", "gets information about the character")]
        public async Task CreateTeam(InteractionContext ctx, [Option("Nickname", "Nickname in Lost Ark")] string NickName)
        {
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            DiscordEmbedBuilder embed=new DiscordEmbedBuilder();
            //добавить ионку класса или что-то другое
            embed.WithAuthor("Author", $"https://лостарк.рф/Оружейная/{NickName}");
            embed.WithDescription("Description");
            embed.WithFooter("Footer", "https://edesigninteractive.com/app/webroot/attachments/News/58/library/mobisystems-com-1920.jpg");
            embed.WithImageUrl("https://static.monopoly.la.gmru.net/efui_iconatlas/acc/acc_112.png");
            embed.WithThumbnail("https://i.pinimg.com/originals/54/74/5c/54745ce8f32c57cedb7d59df92184fe0.jpg");
            embed.WithTitle("Title");
            embed.WithUrl("https://лостарк.рф/Оружейная/Durfald");
            stopwatch.Stop();
            embed.AddField("time", stopwatch.Elapsed.ToString());
            await ctx.CreateResponseAsync(embed);
        }
    }
}
