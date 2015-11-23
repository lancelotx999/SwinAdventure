using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture()]
	public class InventoryTest
	{
		public InventoryTest ()
		{
		}

		[Test()]
		public void FindItemTest()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");
			Inventory TestInventory = new Inventory ();

			TestInventory.PutItem (TestItem);
			Assert.IsTrue (TestInventory.HasItem ("baked"));
		}

		[Test()]
		public void NoFindItemTest()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");
			Inventory TestInventory = new Inventory ();

			TestInventory.PutItem (TestItem);
			Assert.IsFalse (TestInventory.HasItem ("chicken"));
		}

		[Test()]
		public void FetchItemTest()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");
			Inventory TestInventory = new Inventory ();

			TestInventory.PutItem (TestItem);
			Assert.IsTrue (TestInventory.FetchItem ("baked") == TestItem);

			Assert.IsTrue (TestInventory.HasItem ("baked"));
		}

		[Test()]
		public void TakeItemTest()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");
			Inventory TestInventory = new Inventory ();

			TestInventory.PutItem (TestItem);
			Assert.IsTrue (TestInventory.HasItem ("baked"));
			TestInventory.TakeItem (TestItem);

			Assert.IsFalse (TestInventory.HasItem ("baked"));
		}

		[Test()]
		public void ListItemTest()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");
			Item TestItem2 = new Item (new string[] { "chicken", "baked" }, "baked chicken", "a baked chicken");
			Inventory TestInventory = new Inventory ();

			TestInventory.PutItem (TestItem);
			TestInventory.PutItem (TestItem2);

			//Assert.IsTrue (TestItem.ShortDesc == ("A baked potato potato."));

			//ItemList.Add (Check.Name + "\t" + Check.ShortDesc + "\n");
			//"baked potato" + "\t" + "A baked potato potato." + "\n"

			Assert.IsTrue (TestInventory.HasItem ("potato"));
			Assert.IsTrue (TestInventory.HasItem ("chicken"));
			Assert.IsTrue (TestInventory.ItemList ().Contains("baked potato" + "\t" + "A baked potato potato." + "\n"));
			Assert.IsTrue (TestInventory.ItemList ().Contains("baked chicken" + "\t" + "A baked chicken chicken." + "\n"));
		}


	}
}

