using ConsoleApp11.Actives.Ships;

namespace ConsoleApp11.Actives.Players
{
	public abstract class PlayerBase : IPlayer
	{
		protected PlayerBase(string name, Field field, ShipBase[] ships)
		{
			Name = name;
			Field = field;
			Ships = ships;
		}

		public abstract Point SelectPoint(Field enemyField);

		public string Name { get; }

		public Field Field { get; }

		public ShipBase[] Ships { get; }
	}
}