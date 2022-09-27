using DSharpPlus;
using DSharpPlus.EventArgs;
using Phasmophobia_Update_Bot.Variables;

namespace Phasmophobia_Update_Bot.Handlers
{
    internal class ServerMessageCreated
    {
        public static List<string> when = new()
        {
            "when",
            "wen",
            "whn",
            "does"
        };
        public static List<string> update = new()
        {
            "update",
            "updat",
            "change",
            "new",
            "patch",
            "version",
            "changes",
            "live"
        };
        public static async Task GuildReceived
            (DiscordClient client, MessageCreateEventArgs m)
        {
            string message = m.Message.Content.ToLower();
            List<string> words = message.Split(' ').ToList();
            if (words.Intersect(when).Any() && words.Intersect(update).Any())
            {
                await m.Channel.SendMessageAsync($"{m.Author.Mention} The update releases: " +
                    $"<t:{VariableList.UpdateTime}> in your local time");
            }
        }


    }
}
