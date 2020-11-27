using System;
using System.Text;
using ConsoleApp11.Actives.Ships;

namespace ConsoleApp11.Actives
{
	public class Field
	{
		public static int DefaultFieldSize = 9;

		public Field(ShipBase[] ships) : this(DefaultFieldSize, DefaultFieldSize, ships)
		{
		}

		public Field(int sizeX, int sizeY, ShipBase[] ships)
		{
			Cells = new Cell[sizeX, sizeY];

			foreach (var ship in ships)
			foreach (var point in ship.Points)
				Cells[point.X, point.Y] = new Cell(ship);

			for (var i = 0; i < Cells.GetLength(0); i++)
			for (var j = 0; j < Cells.GetLength(1); j++)
				Cells[i, j] = Cells[i, j] ?? new Cell();
		}

		public bool TryStrike(Point point, out ShipBase ship)
		{
			ship = null;

			var cell = Cells[point.X, point.Y];
			cell.IsShotThrough = true;

			if (!cell.HasShip) return false;

			cell.Ship.Strike();
			ship = cell.Ship;
			return true;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();

			for (var i = 0; i < Cells.GetLength(0); i++)
			{
				for (var j = 0; j < Cells.GetLength(1); j++)
					stringBuilder.Append(
						Cells[i, j].IsShotThrough
							? Cells[i, j].HasShip
								? Cells[i, j].Ship.IsDestroyed()
									? "="
									: "-"
								: "0"
							: "_");
				stringBuilder.Append(Environment.NewLine);
			}

			return stringBuilder.ToString();
		}

		public Cell[,] Cells { get; }
	}
}