using System.Collections.Generic;

namespace Sokoban
{
	public class Elem
	{
		public int height = 0;
		public int width = 0;
		public char type = ' ';

		public static void addNewElem(int h, int w, char type, List<Elem> elems)
		{
			Elem elem = new Elem();

			elem.height = h;
			elem.width = w;
			elem.type = type;
			elems.Add(elem);
		}

		public static bool changePlacePlayer(Elem player, int h, int w)
		{
			player.height = h;
			player.width = w;
			return true;
		}
	}
}