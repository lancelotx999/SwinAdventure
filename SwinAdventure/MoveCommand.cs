using System;

namespace SwinAdventure
{
	public class MoveCommand: Command
	{
		public MoveCommand ()
		{
			AddIdentifier("move");
			AddIdentifier("go");
			AddIdentifier("head");
			AddIdentifier("leave");
		}

		public override string Execute (Player p, string[] text)
		{
			if (text.Length == 1 && text [0] != "leave" || text.Length > 3) 
			{
				return "i don't know how to move like that";
			}
				
			if (text [0] != "move" && text [0] != "go" && text [0] != "head" && text [0] != "leave") 
			{
				return "error in move input";
			}

			if (text[0] != "leave")
			{
				if (text[1] != "to" || text.Length < 3)
				{
					return "where do you want to go?";
				}
				else
				{
					return MoveTo(p, text[2]);
				}
			}
			else
			{
				return MoveTo(p, "leave");
			}
		}

		public string MoveTo(Player p, string id)
		{
			Location _location;
			if (id == "leave")
			{
				p.LeaveLocation ();
				return p.Location.LongDesc;

			}

			_location = p.Location;

			Path _path = _location.Path;

			if (_path == null) 
			{
				return "location has no path";
			}

			_location = _path.GetLocation (id);

			if(_location ==null)
			{
				return "path not found";
			}

			p.Location = _location;
			return p.Location.LongDesc;
		}
	}
}

