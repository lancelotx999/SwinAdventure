using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture()]
	public class PlayerTest
	{
		
		public PlayerTest ()
		{
		}

		[Test()]
		public void IdentifyPlayerTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");

			//Assert.IsTrue (TestPlayer.Locate ("TestPlayer")== TestPlayer);

			Assert.IsTrue (TestPlayer.AreYou ("me"));
		}

		[Test()]
		public void LocateItemsTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");

			TestPlayer.Inventory.PutItem (TestItem);

			//Assert.IsTrue (TestPlayer.Locate ("TestPlayer")== TestPlayer);

			Assert.IsTrue (TestPlayer.Locate ("potato") == TestItem);
			Assert.IsTrue (TestPlayer.Locate ("potato") == TestItem);

		}

		[Test()]
		public void LocatePlayerTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");

			//Assert.IsTrue (TestPlayer.Locate ("TestPlayer")== TestPlayer);

			Assert.IsTrue (TestPlayer.Locate ("me") == TestPlayer);
		}

		[Test()]
		public void LocateNothingTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");

			//Assert.IsTrue (TestPlayer.Locate ("TestPlayer")== TestPlayer);

			Assert.IsTrue (TestPlayer.Locate ("potato") == null);
		}

		[Test()]
		public void PlayerFullDescTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");

			TestPlayer.Inventory.PutItem (TestItem);
			//Assert.IsTrue (TestPlayer.Locate ("TestPlayer")== TestPlayer);

			//Assert.IsTrue (TestInventory.ItemList ().Contains("baked potato" + "\t" + "A baked potato potato." + "\n"));
			//Assert.IsTrue (TestInventory.ItemList ().Contains("baked chicken" + "\t" + "A baked chicken chicken." + "\n"));

			Assert.IsTrue (TestPlayer.FullDescription().Contains("You are Carrying: \n" + "baked potato" + "\t" + "A baked potato potato." + "\n" ));
			Console.WriteLine (TestPlayer.FullDescription ());
		}


	}
}

