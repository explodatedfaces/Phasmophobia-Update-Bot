using DSharpPlus;
using DSharpPlus.EventArgs;
using Phasmophobia_Update_Bot.BotConsole;

namespace Phasmophobia_Update_Bot.Handlers
{
    internal class HeartBeated
    {
        public static async Task Heartbeat(DiscordClient client, HeartbeatEventArgs h)
        {
            switch (h.Ping)
            {
                case <= 50:
                    await Custom.Info($"heart beated with ping {h.Ping}");
                    break;
                case >= 51:
                    await Custom.Warning($"heart beated with ping {h.Ping}");
                    break;
            }
        }
    }
}
