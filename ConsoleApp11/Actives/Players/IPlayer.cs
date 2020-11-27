using ConsoleApp11.Actives.Ships;

namespace ConsoleApp11.Actives.Players
{
	public interface IPlayer
	{
		Point SelectPoint(Field enemyField);

		string Name { get; }

		Field Field { get; }

		ShipBase[] Ships { get; }
	}
}