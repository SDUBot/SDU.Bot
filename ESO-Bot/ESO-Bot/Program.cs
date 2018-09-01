using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace ESO_Bot
{
	public class Program
	{
		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();



		public async Task MainAsync()
		{
            var client = new DiscordSocketClient();

            client.Log += Log;
            client.MessageReceived += MessageReceived;

            

            string token = "NDg0MTAwNTk1NjkxODE0OTEy.DmdIvQ.gW18KnVYgqEXQ7Sxbffq_yJsx0Y";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await client.SetGameAsync(DateTime.UtcNow.ToString());

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!lucas")
            {
                await message.Channel.SendMessageAsync("er weeb!");
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
	}
}