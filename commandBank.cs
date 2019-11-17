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

        private async Task helloHelper()
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 12)
            {
                await ReplyAsync("Good Morning!");
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 17)
            {
                await ReplyAsync("Good Afternoon!");
            }
            else if (DateTime.Now.Hour >= 17 && DateTime.Now.Hour < 23)
            {
                await ReplyAsync("Good Evening!");
            }
            else
            {
                await ReplyAsync("Well hello there!");
            }
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
            await helloHelper();
        }
        [Command("hi")]
        public async Task HiAsync()
        {
            ConsoleTime();
            Console.WriteLine("Hello Task Registered");
            await helloHelper();
        }
        [Command("yn")]
        public async Task YNAsync()
        {
            ConsoleTime();
            Console.WriteLine("YesNo Registered");
            var rand = new Random();
            int x = rand.Next(4);
            if (x == 0)
            {
                await ReplyAsync("Strong Yes");
            }
            else if (x == 1)
            {
                await ReplyAsync("Yes");
            }
            else if (x == 2)
            {
                await ReplyAsync("No");
            }
            else
            {
                await ReplyAsync("Strong No");
            }

        }


        //[Command("")]
        //public async Task NAME() { }

    }
}
