﻿namespace KWIJisho
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var bot = new Bot();

            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
