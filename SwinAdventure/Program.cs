using System;

namespace SwinAdventure
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Get the player's name and description from the user, and use these details to create a
			//Player object.
			//■ Create two items and add them to the the player's inventory
			//■ Create a bag and add it to the player's inventory
			//■ Create another item and add it to the bag
			//■ Loop reading commands from the user, and getting the look command to execute them. 
			Console.WriteLine("Enter Player Name:");
			string Name = Console.ReadLine();
			Console.WriteLine ("Describe yourself:");
			string Desc = Console.ReadLine();

			Player GamePlayer = new Player (Name, Desc);
			Item Sword = new Item (new string[] { "Sword", "broadsword" }, "sword", "a broadsword");
			Item Potato = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");

			GamePlayer.Inventory.PutItem (Sword);
			GamePlayer.Inventory.PutItem (Potato);

			Bag Bag1 = new Bag (new string[] { "Test", "Bag" }, "Test Bag", "A Testing Bag");

			GamePlayer.Inventory.PutItem (Bag1);

			Item Gem = new Item (new string[] { "gem", "Shiny" }, "Gem", "A Shiny Gem");
			Bag1.Inventory.PutItem (Gem);

			Location PotatoFarm = new Location (new string[] { "potato", "farm" }, "potato farm", "a potato farm");
			Location MelonFarm = new Location (new string[] { "melon", "farm" }, "melon farm", "a melon farm");
			Location TomatoFarm = new Location (new string[] { "tomato", "farm" }, "tomato farm", "a tomato farm");

			Path PotatoPath = new Path(new string[] { "potato", "path" });
			Path MelonPath = new Path(new string[] { "melon", "path" });
			Path TomatoPath = new Path(new string[] { "tomato", "path" });


			PotatoFarm.Path = PotatoPath;
			PotatoPath.SetLocation('w', MelonFarm);
			PotatoPath.SetLocation('n', TomatoFarm);

			MelonFarm.Path = MelonPath;
			MelonPath.SetLocation('e', PotatoFarm);
			MelonPath.SetLocation('a', TomatoFarm);

			TomatoFarm.Path = TomatoPath;
			TomatoPath.SetLocation('s', PotatoFarm);
			TomatoPath.SetLocation('d', MelonFarm);

			GamePlayer.Location = PotatoFarm;

			CommandProcessor MainCommandProcessor = new CommandProcessor();
			LookCommand Look = new LookCommand ();
			MoveCommand Move = new MoveCommand ();

			MainCommandProcessor.AddCommand (Look);
			MainCommandProcessor.AddCommand (Move);

			do
			{
				Console.WriteLine("Enter Command:");
				string UserInput = Console.ReadLine();
				String[] Command = UserInput.Split(' ');

				Console.WriteLine(MainCommandProcessor.Execute(GamePlayer,Command));
	
			}while(true);
		}


	}
}
