using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture()]
	public class LocationTest
	{
		public LocationTest ()
		{
		}

		[Test()]
		public void AreYouTest()
		{
			Location TestLocation = new Location (new string[] { "potato", "farm" }, "potato farm", "a potato farm");


			Assert.IsTrue (TestLocation.AreYou ("potato"));
			Assert.IsTrue (TestLocation.AreYou ("farm"));
		}

		[Test()]
		public void LocateTest()
		{
			Location TestLocation = new Location (new string[] { "potato", "farm" }, "potato farm", "a potato farm");
			Item TestItem = new Item (new string[] { "gem", "shiny" }, "shiny gem", "a shiny gem");

			TestLocation.Inventory.PutItem (TestItem);

			Assert.IsTrue (TestLocation.Locate ("gem") == TestItem);
		}

		[Test()]
		public void PlayerLocateTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");
			Location TestLocation = new Location (new string[] { "potato", "farm" }, "potato farm", "a potato farm");
			Item TestItem = new Item (new string[] { "gem", "shiny" }, "shiny gem", "a shiny gem");

			TestPlayer.Location = TestLocation;
			TestLocation.Inventory.PutItem (TestItem);

			Assert.IsTrue (TestPlayer.Location.Locate ("gem") == TestItem);
		}
	}
}

