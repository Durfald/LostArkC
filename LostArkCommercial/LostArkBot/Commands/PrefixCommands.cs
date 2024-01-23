using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkCommercial.LostArkBot.Commands
{
    internal class PrefixCommands:BaseCommandModule
    {
        [Command("qwe")]
        [Description("gives the Extension by username")]
        public async Task asd(CommandContext ctx)
        {
            var myButton = new DiscordButtonComponent(ButtonStyle.Primary, "my_custom_id", "This is a button!");

            var builder = new DiscordMessageBuilder()
                .WithContent("This message has buttons! Pretty neat innit?")
                .AddComponents(myButton);
            await ctx.Channel.SendMessageAsync(builder);
        }
    }
}