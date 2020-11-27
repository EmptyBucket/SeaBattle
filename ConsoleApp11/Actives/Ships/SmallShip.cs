using System;

namespace ConsoleApp11.Actives.Ships
{
	public class SmallShip : ShipBase
	{
		public SmallShip(Point[] points) : base(points)
		{
			const int size = 1;
			
			if (points.Length != size)
				throw new ArgumentException($"{nameof(points)}.{nameof(points.Length)} must be {size}");
		}
	}
}