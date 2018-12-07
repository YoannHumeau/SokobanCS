using System;
using System.Collections.Generic;

namespace Sokoban
{
    public class GameOver
    {
		public static bool isGameOver(List<Elem> points, List<Elem> boxes)
		{
			bool check = false;

			// for each points, we check if there is anay same location with each box
			// if 1 have no box, no gameover winning
			foreach (Elem point in points)
			{
				check = false;

				foreach (Elem box in boxes)
					if (box.height == point.height && box.width == point.width)
						check = true;

				if (!check)
					return false;
			}
			Console.Clear();
			Console.WriteLine("\n\n\n\t\tYOU WIN !!!");

			return true;
		}
    }
}