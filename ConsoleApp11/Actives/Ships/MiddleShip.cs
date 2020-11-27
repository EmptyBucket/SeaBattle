using System;

namespace ConsoleApp11.Actives.Ships
{
	public class MiddleShip : ShipBase
	{
		public MiddleShip(Point[] points) : base(points)
		{
			const int size = 2;
			
			if (points.Length != size)
				throw new ArgumentException($"{nameof(points)}.{nameof(points.Length)} must be {size}");
		}
	}
}