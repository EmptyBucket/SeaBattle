using System.IO;

namespace ConsoleApp11
{
	class Program
	{
		static void Main(string[] args)
		{
			var text = File.ReadAllText("Ships.txt");
			var players = InitParser.ParsePlayers(text);
			new Game(players).Start();
		}
	}
}