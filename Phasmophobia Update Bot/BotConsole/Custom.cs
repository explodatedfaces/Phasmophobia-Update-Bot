namespace Phasmophobia_Update_Bot.BotConsole
{
    internal class Custom
    {
        public static async Task Error(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Task.Run(() => Console.WriteLine($"[ERROR] [{DateTime.Now}] " + error));
            await Task.Run(() => Console.Beep());
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static async Task Warning(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            await Task.Run(() => Console.WriteLine($"[WARN] [{DateTime.Now}] " + warning));
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static async Task Info(string info)
        {
            await Task.Run(() => Console.WriteLine($"[INFO] [{DateTime.Now}] " + info));
        }
    }
}
