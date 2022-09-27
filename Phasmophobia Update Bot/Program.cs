using DSharpPlus;
using Microsoft.Extensions.Logging;
using Phasmophobia_Update_Bot.BotConsole;
using Phasmophobia_Update_Bot.Handlers;
using Phasmophobia_Update_Bot.Variables;

namespace Phasmophobia_Update_Bot
{
    /*
     * The creator of this bot has dedicated the work to the 
     * public domain, under the conditions listed below intended
     * to protect Kinetic Games, by waiving all of his rights to
     * the work worldwide under copyright law, including all related 
     * and neighboring rights, to the extent allowed by law.
     * You can copy, modify, distribute and perform the work,
     * even for commercial purposes, all without asking permission for so
     * long as you, the user, modifier, distributor, or performer
     * obey the below required condition. 
     * 
     * This program is distributed as-is with no warranty expressed 
     * or implied of or for its usability, suitability for a 
     * particular purpose, merchantability, or safety.
     * 
     * Phasmophobia, the Phasmophobia logo and Kinetic Games are 
     * either ® or TM, Kinetic Games Limited. The creator of this
     * bot has no rights to or ownership of Phasmophobia, the 
     * Phasmophobia logo, or Kinetic games or their works. 
     * Upon demand of Kinetic Games or any employee, agent, or
     * other person so authorized by Kinetic games you must immediately
     * cease and desist from the use of any of their copyrighted works.
     * Kinetic Games did not create this bot and cannot offer
     * assistance with it. Kinetic Games is not responsible for any
     * content contained herein.
     */
    internal class Program
    {
        static int recursiveRestarts = 0;
        static void Main()
        {
            var bot = Task.Run(() => MainAsync());
            bot.Wait();
            if ((bot.IsCanceled
                || bot.IsFaulted
                || bot.IsCompleted
                || bot.IsCompletedSuccessfully)
                && recursiveRestarts < 5)
            {
                recursiveRestarts++;
                var errorReported = Task.Run(() =>
                    Custom.Error($"The bot unexpectedly stopped... " +
                    $"restarting for the {recursiveRestarts}th time."));
                Main();
            }
            else
            {
                var errorReported = Task.Run(() =>
                    Custom.Error($"The bot unexpectedly stopped {recursiveRestarts} times... " +
                    $"no more attemps left."));
            }
        }
        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration
            {
                Token = VariableList.BotToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.Guilds
                | DiscordIntents.GuildMessages
                | DiscordIntents.DirectMessages
                | DiscordIntents.DirectMessageTyping
                | DiscordIntents.GuildPresences,
                MinimumLogLevel = LogLevel.Warning,
                AutoReconnect = true
            });

            discord.MessageCreated += async (discordClient, messageEventArgs) =>
            {
                await Task.Run(() => ServerMessageCreated.GuildReceived(discordClient, messageEventArgs));
            };
            discord.Heartbeated += async (discordClient, heartbeatEventArgs) =>
            {
                await Task.Run(() => HeartBeated.Heartbeat(discordClient, heartbeatEventArgs));
            };
            discord.Zombied += async (discordClient, zombiedEventArgs) =>
            {
                await Task.Run(() => Zombie.Zombied(discordClient, zombiedEventArgs));
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
            await discord.DisconnectAsync();
        }
    }
}