using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phasmophobia_Update_Bot.Variables
{
    internal class VariableList
    {
        public static string UpdateTime = File.ReadAllTextAsync("./timestamp.txt").Result;
        public static string BotToken = File.ReadAllTextAsync("./token.txt").Result;
    }
}
