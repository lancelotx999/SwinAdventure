using System;

namespace SwinAdventure
{
	public class Path:IdentifiableObject
	{
		Location _north;
		Location _south;
		Location _east;
		Location _west;
		Location _north_east;
		Location _north_west;
		Location _south_east;
		Location _south_west;

		public Path (string[] ids)
		{
			_north = null;
			_south = null;
			_east = null;
			_west = null;
			_north_east = null;
			_north_west = null;
			_south_east = null;
			_south_west = null;

			foreach(string id in ids)
			{
				this.AddIdentifier (id);
			}

		}
			
		public void SetLocation(char direction, Location location)
		{
			if (location == null) 
			{
				return;
			}
			switch(direction)
			{
			case 'n':
				_north = location;
				break;
			case 's':
				_south = location;
				break;
			case 'e':
				_east = location;
				break;
			case 'w':
				_west = location;
				break;
			case 'a':
				_north_east = location;
				break;
			case 'b':
				_north_west = location;
				break;
			case 'c':
				_south_east = location;
				break;
			case 'd':
				_south_west = location;
				break;
			}
		}

		public Location GetLocation(string direction)
		{
			if (direction == "n" || direction == "up" || direction == "north") {
				return _north;
			} else if (direction == "s" || direction == "down" || direction == "south") {
				return _south;
			} else if (direction == "e" || direction == "east") {
				return _east;
			} else if (direction == "w" || direction == "west") {
				return _west;
			} else if (direction == "a" || direction == "north_east") {
				return _north_east;
			} else if (direction == "b" || direction == "north_west") {
				return _north_west;
			} else if (direction == "c" || direction == "south_east") {
				return _south_east;
			} else if (direction == "d" || direction == "south_west") {
				return _south_west;
			} else {
				if (_north != null) {
					if (_north.AreYou (direction)) {
						return _north;
					} 
				}
				if (_south != null) {
					if (_south.AreYou (direction)) {
						return _south;
					} 
				}
				if (_east != null) {
					if (_east.AreYou (direction)) {
						return _east;
					} 
				}
				if (_west != null) {
					if (_west.AreYou (direction)) {
						return _west;
					} 
				}
				if (_north_east != null) {
					if (_north_east.AreYou (direction)) {
						return _north_east;
					} 
				}
				if (_north_west != null) {
					if (_north_west.AreYou (direction)) {
						return _north_west;
					} 
				}
				if (_south_east != null) {
					if (_south_east.AreYou (direction)) {
						return _south_east;
					} 
				}
				if (_south_west != null) {
					if (_south_west.AreYou (direction)) {
						return _south_west;
					} 
				}
				return null;
			}
		}
	}
}

