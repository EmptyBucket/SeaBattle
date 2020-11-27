using System;
using System.Linq;
using System.Reflection;
using ConsoleApp11.Actives;
using ConsoleApp11.Actives.Players;
using ConsoleApp11.Actives.Ships;

namespace ConsoleApp11
{
	public static class InitParser
	{
		public static IPlayer[] ParsePlayers(string text) =>
			text.Split(Environment.NewLine + Environment.NewLine).Select(ParsePlayer).ToArray();

		private static IPlayer ParsePlayer(string block)
		{
			var lines = block.Split(Environment.NewLine);
			var name = lines[0];
			var ships = lines.Skip(1).Select(ParseShip).ToArray();
			var field = new Field(ships);

			var playerInterface = typeof(IPlayer);
			var humanPlayerType = typeof(HumanPlayer);
			var playerType =
				Assembly.GetExecutingAssembly().GetTypes()
					.SingleOrDefault(t => playerInterface.IsAssignableFrom(t) && t != humanPlayerType &&
					                      t.Name.Replace("Player", "") == name)
				?? humanPlayerType;

			return (IPlayer) Activator.CreateInstance(playerType, name, field, ships);
		}

		private static ShipBase ParseShip(string line)
		{
			var points = line
				.Split(' ')
				.Select((cord, index) => (Index: index, Value: int.Parse(cord)))
				.GroupBy(cord => cord.Index / 2, (g, cords) => cords.ToArray())
				.Select(cords => new Point(cords[0].Value, cords[1].Value))
				.ToArray();

			return points.Length switch
			{
				1 => new SmallShip(points),
				2 => new MiddleShip(points),
				3 => new BigShip(points),
				_ => throw new ArgumentException("Ship is too big")
			};
		}
	}
}