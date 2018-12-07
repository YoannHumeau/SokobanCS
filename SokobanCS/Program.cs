using System;
using System.Collections.Generic;

namespace Sokoban
{
	class Program
	{
		static void Main(string[] args)
		{
			bool gameOver = false;
			ConsoleKeyInfo inputKey;
			List<Elem> player = new List<Elem>();
			List<Elem> boxes = new List<Elem>();
			List<Elem> points = new List<Elem>();
			Map map = new Map();

			// Load the map
			map.loadedMap();

			// Find elements in the map and stock information
			map.getElementsPosition(player, boxes, points);
			
			while (!gameOver)
			{
				Console.WriteLine("\nPlayer " + player[0].height + " - " + player[0].width);
				map.printMap(map.lines, player, boxes, points);
				inputKey = Console.ReadKey();
				Console.Clear();
				Moving.askToMove(player[0], boxes, inputKey, map.lines);
				gameOver = GameOver.isGameOver(points, boxes);
			}

			Console.ReadLine();
        }
    }
}