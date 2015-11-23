using System;

namespace SwinAdventure
{
	public class Location:GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private Path _path;

		public Location (string[] ids, string name, string desc)
		{
			_inventory = new Inventory ();
			this.Name = name;
			this.LongDesc = desc;

			foreach(string id in ids)
			{
				this.AddIdentifier (id);
			}
		}

		public GameObject Locate(string id)
		{
			if (this.AreYou (id)) 
			{
				return this;
			} 
			else if (this.Inventory.HasItem (id)) 
			{
				return this.Inventory.FetchItem (id);
			}
			return null;
		}

		public Inventory Inventory 
		{
			get 
			{
				return _inventory;
			}
			set 
			{
				_inventory = value;
			}
		}

		public Path Path 
		{
			get 
			{
				return _path;
			}
			set 
			{
				_path = value;
			}
		}


	}
}

