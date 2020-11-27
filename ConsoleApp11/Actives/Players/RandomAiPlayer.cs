using ConsoleApp11.Actives.Ships;

namespace ConsoleApp11.Actives.Players
{
	public class RandomAiPlayer : PlayerBase
	{
		public RandomAiPlayer(string name, Field field, ShipBase[] ships) : base(name, field, ships)
		{
		}

		public override Point SelectPoint(Field enemyField)
		{
			throw new System.NotImplementedException();
		}
	}
}