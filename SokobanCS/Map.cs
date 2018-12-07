using System;
using System.Collections.Generic;

namespace Sokoban
{
	class Map
	{
		public List<string> lines;

		public void loadedMap()
		{
			List<string> listline = new List<string>();

			listline.Add("#############################");
			listline.Add("#                           #");
			listline.Add("#                           #");
			listline.Add("#               #############");
			listline.Add("#                           #");
			listline.Add("#                           #");
			listline.Add("#                           #");
			listline.Add("#                 ###########");
			listline.Add("#                           #");
			listline.Add("#               O X      OX #");
			listline.Add("#                          P#");
			listline.Add("#############################");

			this.lines = listline;
		}

		public static void replaceCaracterInMap(int height, int width, char newCharacter, List<string> linesMap)
		{
			char[] charArray = linesMap[height].ToCharArray();
			charArray[width] = newCharacter;
			charArray.ToString();
			string newString = new string(charArray);
			linesMap[height] = newString;
		}

		public void getElementsPosition(List<Elem> player, List<Elem> boxes, List<Elem> points)
		{
			int h = 0; // height
			int w = 0; // width
			List<string> linesTemp = new List<string>(lines);
			
			// Parsing map for finding boxes, points, qnd player position
			foreach (string line in linesTemp)
			{
				for (w = 0; w < line.Length; w++)
				{
					switch (line[w])
					{
						case 'X':
							Elem.addNewElem(h, w, 'X',  boxes);
							replaceCaracterInMap(h, w, ' ', this.lines);
							break;

						case 'O':
							Elem.addNewElem(h, w, 'O', points);
							replaceCaracterInMap(h, w, ' ', this.lines);
							break;

						case 'P':
							Elem.addNewElem(h, w, 'P', player);
							replaceCaracterInMap(h, w, ' ', this.lines);
							break;
					}
				}
				h++;
			}
		}

		public void printMap(List<string> linesMap, List<Elem> player, List<Elem> boxes, List<Elem> points)
		{
			List<string> linesMapPrint = new List<string>(linesMap);

			foreach (Elem point in points)
				replaceCaracterInMap(point.height, point.width, 'O', linesMapPrint);

			foreach (Elem box in boxes)
				replaceCaracterInMap(box.height, box.width, 'X', linesMapPrint);

			replaceCaracterInMap(player[0].height, player[0].width, 'P', linesMapPrint);

			foreach (string line in linesMapPrint)
				Console.WriteLine(line);
		}
	}
}