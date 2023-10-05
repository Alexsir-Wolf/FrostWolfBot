using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace FrostWolfBot.Comandos
{
	public class ComandoPing : BaseCommandModule
	{
		[Command("ping")]
		public async Task Ping(CommandContext context)
		{
			await context.Channel.SendMessageAsync($"Pong!");
		}

	}
}
