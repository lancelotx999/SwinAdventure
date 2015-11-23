using System;

namespace SwinAdventure
{
	public class Item: GameObject
	{
		public Item()
		{
		}

		public Item (string[] idents, string name, string desc)
		{
			Name = name;
			LongDesc = desc;

			foreach(string id in idents)
			{
				this.AddIdentifier (id);
			}
		}


	}
}

