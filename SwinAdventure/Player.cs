using System;

namespace SwinAdventure
{
	public class Player:GameObject,IHaveInventory
	{
		private Inventory _inventory;
		private Location _location;
		private Location _lastlocation;

		public Player()
		{
		}

		public Player (string name, string desc):base(new string[] { "me", "inventory"} , name, desc) 
		{
			this.Name = name;
			this.LongDesc = desc;

			_inventory = new Inventory ();

			_location = null;
			_lastlocation = null;
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

		public string FullDescription()
		{
			string InventoryDescription = "You are Carrying: \n";
			foreach (string Item in _inventory.ItemList ()) 
			{
				InventoryDescription = InventoryDescription + Item;
			}
			return InventoryDescription;
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
			
		public Location Location 
		{
			get 
			{
				return _location;
			}
			set
			{
				if (_location == null) 
				{
					_lastlocation = value;
				} 
				else 
				{
					_lastlocation = _location;
				}
				_location = value;
			}
		}

		public void LeaveLocation()
		{
			_location = _lastlocation;
		}
	}
}

