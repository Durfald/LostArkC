using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.EventArgs;
using LostArkCommercial.LostArkBot.Commands;
using LostArkCommercial.LostArkBot.Other;
using Microsoft.Extensions.Logging;

namespace LostArkCommercial.LostArkBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; } = null!;

        public CommandsNextExtension commands { get; private set; } = null!;

        public SlashCommandsExtension slashcommands { get; private set; } = null!;
        public async Task RunAsync()
        {
            var ConfigJson = Config.Load();
            var DiscordBotConfig = new DiscordConfiguration()
            {
                Token=ConfigJson.Token,
                TokenType=TokenType.Bot,
                AutoReconnect=true,
                MinimumLogLevel=LogLevel.Debug,
                Intents=DiscordIntents.All
            };

            Client = new DiscordClient(DiscordBotConfig);

            Client.Ready += Client_Ready;
            //var commandsConfig = new CommandsNextConfiguration
            //{
            //    StringPrefixes = ConfigJson.Prefixes,
            //    EnableMentionPrefix = true,
            //    EnableDms = true,
            //    DmHelp = true,
            //}; 

            slashcommands = Client.UseSlashCommands();
            //commands = Client.UseCommandsNext(commandsConfig);
            //commands.CommandErrored += Commands_CommandErrored;
            slashcommands.SlashCommandErrored += Slashcommands_SlashCommandErrored;
            Client.GuildCreated += Client_GuildCreated;
            Client.ComponentInteractionCreated += Client_ComponentInteractionCreated;
            slashcommands.RegisterCommands<SlashCommands>();
            //commands.RegisterCommands<PrefixCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task Client_ComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs args)
        {
            return Task.CompletedTask;
        }

        private Task Client_GuildCreated(DiscordClient sender, GuildCreateEventArgs args)
        {
            return Task.CompletedTask;
        }

        private Task Slashcommands_SlashCommandErrored(SlashCommandsExtension sender, SlashCommandErrorEventArgs args)
        {
            if (!Directory.Exists("SlashCommandErrors"))
                Directory.CreateDirectory("SlashCommandErrors");
            File.WriteAllText(Path.Combine("SlashCommandErrors", DateTime.UtcNow.ToString("yyyy.MM.dd HH.mm.ss") + ".txt"), args.Exception.ToString());
            Logging.ConsoleLog(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private Task Commands_CommandErrored(CommandsNextExtension sender, CommandErrorEventArgs args)
        {
            if (!Directory.Exists("CommandErrors"))
                Directory.CreateDirectory("CommandErrors");
            File.WriteAllText(Path.Combine("CommandErrors",DateTime.UtcNow.ToString("yyyy.MM.dd HH.mm.ss")+ ".txt"),args.Exception.ToString());
            Logging.ConsoleLog(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            Logging.ConsoleLog("\r\n" + sender.CurrentApplication.Name + " Ready\r\n");
            return Task.CompletedTask;
        }
    }
}
