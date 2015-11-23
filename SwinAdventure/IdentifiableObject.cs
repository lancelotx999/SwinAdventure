using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class IdentifiableObject
	{
		private List<string> _identifier = new List<string>();

		public IdentifiableObject()
		{
		}

		public IdentifiableObject (String[] Idents)
		{
			_identifier.AddRange (Idents);
		}

		public bool AreYou(string id)
		{
			foreach (string Check in _identifier) 
			{
				if (id == Check) 
				{
					return true;
				}
			}
			return false;
		}

		public string FirstId
		{
			get 
			{
				return _identifier.First ();
			}
		}

		public void AddIdentifier(string id)
		{
			_identifier.Add (id.ToLower ());

		}




	}
}

