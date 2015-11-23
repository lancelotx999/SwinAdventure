using System;

namespace SwinAdventure
{
	public class LookCommand:Command
	{
		public LookCommand ()
		{
			this.AddIdentifier ("look");
		}

		public override string Execute (Player p, string[] text)
		{
			
			if (text.Length  != 3 && text.Length != 5) 
			{
				return "i don't know how to look like that";
			}
				
			if (text [0] != "look") 
			{
				return "error in look input";
			}
			
			if (text [1] != "at") 
			{
				return "what do you want to look at?";
			}
			
			if (text.Length == 5 && text [3] != "in") 
			{
				return "what do you want to look in?";
			} 
			else if (text.Length == 5) 
			{
				return this.LookAtIn (p, text [2], text [4]);
			} 
			else 
			{
				return this.LookAtIn (p, text [2], "");
			}
		}

		public string LookAtIn(Player p, string thingId, string containerId)
		{
			
			if (p.AreYou(thingId))
			{
				return p.LongDesc;
			}
				
			GameObject wantedItem = null;
			IHaveInventory wantedInventory = p.Locate(containerId) as IHaveInventory;

			if (p.AreYou (containerId) || containerId == "") 
			{
				wantedInventory = (IHaveInventory)p;
				//return p.LongDesc;
			}

			if (wantedInventory == null) 
			{
				return "i cannot find the " + containerId;
			}

			wantedItem = wantedInventory.Locate (thingId);

			if (wantedItem == null) 
			{
				if (containerId == "") 
				{
					return "i cannot find the " + thingId;
				} 
				else 
				{
					return "i cannot find the " + thingId + " in " + containerId;
				}
			}
				
			return wantedItem.LongDesc;
		}
	}
}

