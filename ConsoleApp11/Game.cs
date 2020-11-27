using System;
using System.Linq;
using ConsoleApp11.Actives.Players;

namespace ConsoleApp11
{
	public class Game
	{
		private readonly IPlayer[] _players;

		public Game(IPlayer[] players)
		{
			if (players.Length != 2) throw new ArgumentException("Players count must be 2");

			_players = players;
		}

		public void Start()
		{
			while (true)
				for (var i = 0; i < _players.Length; i++)
				{
					var player = _players[i];
					var enemy = _players[i == 0 ? 1 : 0];
					Step(player, enemy);

					if (enemy.Ships.All(s => s.IsDestroyed()))
					{
						Console.WriteLine($"{nameof(HumanPlayer)} with name {player.Name} win");
						return;
					}
				}
		}

		private static void Step(IPlayer player, IPlayer enemy)
		{
			Console.WriteLine($"Your next step, player {player.Name}");
			Console.WriteLine(enemy.Field.ToString());
			var point = player.SelectPoint(enemy.Field);
			Console.WriteLine(enemy.Field.TryStrike(point, out var ship)
				? ship.IsDestroyed()
					? "Your destroy ship"
					: "Your strike on ship"
				: "Your miss");
		}
	}
}