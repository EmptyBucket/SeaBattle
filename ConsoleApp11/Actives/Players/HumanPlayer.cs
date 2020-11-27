using System;
using ConsoleApp11.Actives.Ships;

namespace ConsoleApp11.Actives.Players
{
	public class HumanPlayer : PlayerBase
	{
		public HumanPlayer(string name, Field field, ShipBase[] ships) : base(name, field, ships)
		{
		}

		public override Point SelectPoint(Field enemyField)
		{
			Console.WriteLine("Enter X cord:");
			var x = int.Parse(Console.ReadLine()!);
			Console.WriteLine("Enter Y cord:");
			var y = int.Parse(Console.ReadLine()!);
			return new Point(x, y);
		}
	}
}