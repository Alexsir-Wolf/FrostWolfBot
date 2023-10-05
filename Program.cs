using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using FrostWolfBot.Comandos;
using FrostWolfBot.config;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FrostWolfBot
{
	public class Program
	{
        private static DiscordClient Cliente { get; set; }
        private static CommandsNextExtension Comandos { get; set; }

        static async Task Main(string[] args)
		{
			var lerJson = new configJSON();
			await lerJson.LerJSON();

			var discordConfig = new DiscordConfiguration()
			{
				Intents = DiscordIntents.All,
				Token = lerJson.Token,
				TokenType = TokenType.Bot,
				AutoReconnect = true,
			};

			Cliente = new DiscordClient(discordConfig);

			Cliente.Ready += Cliente_Ready;

			var comandosConfig = new CommandsNextConfiguration()
			{
				StringPrefixes = new string[] { lerJson.Prefix },
				EnableMentionPrefix = true,
				EnableDms = true,
				EnableDefaultHelp = false,
			};

			Comandos = Cliente.UseCommandsNext(comandosConfig);
			
			Comandos.RegisterCommands<ComandoPing>();

			await Cliente.ConnectAsync();
			await Task.Delay(-1);
		}

		private static Task Cliente_Ready(DiscordClient sender, ReadyEventArgs args)
		{
			return Task.CompletedTask;
		}
	}
}
