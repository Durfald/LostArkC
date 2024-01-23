using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkCommercial.LostArkBot.Other
{
    public static class Logging
    {
        static string DateTimeFormat => "yyyy.MM.dd HH.mm.ss";
        public static void ConsoleLog(string o)=>Console.WriteLine($"{DateTime.UtcNow.ToString(DateTimeFormat)}:: {o}");
        public static void LogFile(string Log)
        {
            var path= Path.Combine("Log", DateOnly.FromDateTime(DateTime.UtcNow).ToString() + ".txt");
            if (!Directory.Exists("Log"))
                Directory.CreateDirectory("Log");
            if(!File.Exists(path))
                File.WriteAllText(path, $"{DateTime.UtcNow.ToString(DateTimeFormat)}::\r\n{Log}\r\n\r\n");
            else
            {
                var content=File.ReadAllText(path);
                content += $"{DateTime.UtcNow.ToString(DateTimeFormat)}::\r\n{Log}\r\n\r\n";
                File.WriteAllText(path, content);
            }
        }
    }
}