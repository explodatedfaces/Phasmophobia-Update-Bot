namespace Phasmophobia_Update_Bot.Variables
{
    internal class VariableList
    {
        public static string UpdateTime = File.ReadAllTextAsync("./timestamp.txt").Result;
        public static string BotToken = File.ReadAllTextAsync("./token.txt").Result;
    }
}
