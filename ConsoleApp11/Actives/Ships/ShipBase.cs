namespace ConsoleApp11.Actives.Ships
{
	public abstract class ShipBase
	{
		private int _countBroken;

		protected ShipBase(Point[] points) => Points = points;

		public void Strike() => _countBroken++;

		public bool IsDestroyed() => Size == _countBroken;

		public int Size => Points.Length;

		public Point[] Points { get; }
	}
}