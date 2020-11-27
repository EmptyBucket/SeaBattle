using System;

namespace ConsoleApp11.Actives.Ships
{
	public class BigShip : ShipBase
	{
		public BigShip(Point[] points) : base(points)
		{
			const int size = 3;
			
			if (points.Length != size)
				throw new ArgumentException($"{nameof(points)}.{nameof(points.Length)} must be {size}");
		}
	}
}