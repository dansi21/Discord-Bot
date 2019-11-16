using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1.commands
{
    public class commandBank : ModuleBase<SocketCommandContext>
    {
        public void ConsoleTime()
        {
            Console.Write(DateTime.Now);
            Console.Write(" --- ");
        }

        [Command("test")]
        public async Task TestAsync(){
            ConsoleTime();
            Console.WriteLine("Test Task Registered");
            await ReplyAsync("Operational");
        }
        [Command("hello")]
        public async Task HelloAsync()
        {
            ConsoleTime();
            Console.WriteLine("Hello Task Registered");
            await ReplyAsync("Well hello there!");
        }


        //[Command("")]
        //public async Task NAME() { }

    }
}
