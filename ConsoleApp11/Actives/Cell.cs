using ConsoleApp11.Actives.Ships;

namespace ConsoleApp11.Actives
{
	public class Cell
	{
		public Cell()
		{
		}

		public Cell(ShipBase ship) => Ship = ship;

		public ShipBase Ship { get; }

		public bool HasShip => Ship != null;

		public bool IsShotThrough { get; set; }
		
	}
}