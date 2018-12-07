using System; 
using System.Collections.Generic;

namespace Sokoban
{
public class Moving
	{
		public int num = 1;

		public static bool askToMove(Elem item, List<Elem> boxes, ConsoleKeyInfo inputKey, List<string> linesMap) // POURQUOI JE NE PEUX PAS AJOUTER ELEM ICI ???????
		{
			int h = item.height;
			int w = item.width;
			int stop = 0;
		
			switch (inputKey.Key)
			{
				case ConsoleKey.UpArrow:
					h--;
					break;
				case ConsoleKey.DownArrow:
					h++;
					break;
				case ConsoleKey.LeftArrow:
					w--;
					break;
				case ConsoleKey.RightArrow:
					w++;
					break;
			}

			// Stop everything if detection of a box pushing a box
			foreach (Elem box in boxes)
				if (box.height == h && box.width == w && item.type == 'X')
					return false;

			// if the place to go for item is a box, ask recurcivly this function
			// if return false (ex : a box push a box, or a box push a wall) return false
			foreach (Elem box in boxes)
				if (box.height == h && box.width == w)
					if (!askToMove(box, boxes, inputKey, linesMap))
						return false;

			// if place to go is a wall return false
			if (linesMap[h][w] == '#')
				return false;

			Elem.changePlacePlayer(item, h, w);
			return true;
		}

		public static char placeCharIs(int h, int w, List<string> linesMap)
		{
			return linesMap[h][w];
		}
	}
}