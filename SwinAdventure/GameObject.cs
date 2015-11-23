using System;

namespace SwinAdventure
{
	public abstract class GameObject: IdentifiableObject
	{
		private string _name;
		private string _desc;

		public GameObject()
		{
		}

		public GameObject (string[] ids, string name, string desc)
		{
			_name = name;
			_desc = desc;

			foreach(string id in ids)
			{
				this.AddIdentifier (id);
			}

		}

		public string Name
		{
			get 
			{
				return _name;
			}
			set 
			{
				_name = value;
			}
		}

		public string ShortDesc
		{
			get 
			{
				return "A " + _name + " " + this.FirstId+ ".";
			}
		}

		public string LongDesc
		{
			get 
			{
				return _desc;
			}
			set 
			{
				_desc = value;
			}
		}
	}
}

