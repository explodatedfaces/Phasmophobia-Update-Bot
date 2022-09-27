using DSharpPlus;
using DSharpPlus.EventArgs;
using Phasmophobia_Update_Bot.BotConsole;

namespace Phasmophobia_Update_Bot.Handlers
{
    internal class Zombie
    {
        static int zombieCount = 0;
        public static async Task Zombied(DiscordClient client, ZombiedEventArgs z)
        {
            zombieCount++;
            await Custom.Error("Zombied hanbdler called");
            await Custom.Warning($"Missed beats: {z.Failures}");
            await Custom.Warning($"Failure during guild download: {z.GuildDownloadCompleted}");
            if (zombieCount < 5)
                await client.ConnectAsync();
        }
    }
}
