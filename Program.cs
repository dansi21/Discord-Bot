using System;
using Discord;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;

namespace ConsoleApp1
{
    public class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _service;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _service = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();
            
            _client.Log += Log;
            //_client.UserJoined += UserJoinedGuild;


            var Bottoken = "TOKEN HERE";
            await RegisterCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, Bottoken);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task RegisterCommandsAsync()
        {
            //_client.UserJoined += AutoAssignBaseRole;
            _client.MessageReceived += HandleCommandsAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(),_service);
        }

        private async Task HandleCommandsAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot)
                return;
            int position = 0;

            if (message.HasMentionPrefix(_client.CurrentUser, ref position) || message.HasStringPrefix("$",ref position) || message.Content.Contains("DasaniBot#6081"))
            {
                var context = new SocketCommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, position, _service);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }

        }
        /*
        private async Task UserJoinedGuild(IGuildUser user) {
        var guild = user.Guild;
        var role = guild.Roles.Any(x => x.Name == "The Bois");
        //FirstOrDefault(x => x.Name.ToString() == "The Bois");
        await (user as IGuildUser).AddRoleAsync(role);
        }
        */

        public void ConsoleTime()
        {
            Console.Write(DateTime.Now);
            Console.Write(" --- ");
        }

        private Task Log(LogMessage msg)
        {
            ConsoleTime();
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}

