using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class CommandProcessor: Command
	{
		private List<Command> _Commands = new List<Command>();

		public CommandProcessor ()
		{
			//foreach(string id in ids)
			//{
			//	this.AddIdentifier (id);
			//}
		}

		public override string Execute(Player p, string[] text)
		{
			foreach (Command command in _Commands)
			{
				if (command.AreYou (text [0])) 
				{
					return command.Execute (p, text);
				}
			}

			return "no such command";
		}

		public void AddCommand(Command NewCommand)
		{
			_Commands.Add (NewCommand);
		}
	}
}

