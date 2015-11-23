using System;

namespace SwinAdventure
{
	public abstract class Command: IdentifiableObject
	{
		public Command()
		{
		}

		public Command (String [] ids)
		{
			foreach(string id in ids)
			{
				this.AddIdentifier (id);
			}
		}
		abstract public string Execute (Player p, string[ ] text);

	}
}

