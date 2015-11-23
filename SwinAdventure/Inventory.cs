using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class Inventory: GameObject
	{
		private List<Item> _inventory;

		public Inventory ()
		{
			_inventory = new List<Item> ();
		}
			
		public bool HasItem(string id)
		{

			foreach (Item Check in _inventory) 
			{
				if (Check.AreYou(id)==true) 
				{
					return true;
				}
			}
			return false;
		}

		public void PutItem(Item NewItem)
		{
			_inventory.Add (NewItem);
		}

		public Item TakeItem(Item NewItem)
		{
			bool RemoveApproval = false;

			foreach (Item Check in _inventory) 
			{
				if (NewItem == Check) 
				{
					RemoveApproval = true;
				}
			}

			if (RemoveApproval == true) 
			{
				_inventory.Remove (NewItem);
				return NewItem;
			} 
			else 
			{
				return null;
			}
		}

		public Item FetchItem(string id)
		{

			foreach (Item InventoryItem in _inventory) 
			{
				if (InventoryItem.AreYou (id) == true) 
				{
					return InventoryItem;
				}

			}

			return null;

		}

		public List<string> ItemList()
		{
			List<string> ItemList = new List<string> ();

			foreach (Item Check in _inventory) 
			{
				ItemList.Add (Check.Name + "\t" + Check.ShortDesc + "\n");
			}

			return ItemList;
		}


	}
}

