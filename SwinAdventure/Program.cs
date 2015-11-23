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

			string Name = Console.ReadLine();
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


			LookCommand TestLook = new LookCommand ();

			do
			{
				string UserInput = Console.ReadLine();
				String[] Command = UserInput.Split(' ');

				Console.WriteLine(TestLook.Execute(GamePlayer,Command));
	
			}while(true);
		}


	}
}
