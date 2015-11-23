using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture()]
	public class BagTest
	{
		public BagTest ()
		{
		}

		[Test()]
		public void LocateTest()
		{
			Bag TestBag = new Bag (new string[] { "Test", "Bag" }, "Test Bag", "A Testing Bag");

			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");

			TestBag.Inventory.PutItem (TestItem);

			Assert.IsTrue (TestBag.Locate ("potato") == TestItem);
		}

		[Test()]
		public void LocateSelfTest()
		{
			Bag TestBag = new Bag (new string[] { "Test", "Bag" }, "Test Bag", "A Testing Bag");

			Assert.IsTrue (TestBag.Locate ("test") == TestBag);
		}

		[Test()]
		public void LocateNullTest()
		{
			Bag TestBag = new Bag (new string[] { "Test", "Bag" }, "Test Bag", "A Testing Bag");

			Assert.IsTrue (TestBag.Locate ("testfail") == null);
		}

		[Test()]
		public void FullDescriptionTest()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");
			Item TestItem2 = new Item (new string[] { "chicken", "baked" }, "baked chicken", "a baked chicken");
			Bag TestBag = new Bag (new string[] { "Test", "Bag" }, "Test Bag", "A Testing Bag");

			TestBag.Inventory.PutItem (TestItem);
			TestBag.Inventory.PutItem (TestItem2);

			Assert.IsTrue (TestBag.FullDescription ().Contains("In "+ TestBag.Name +"You are Carrying: \n"));
			Assert.IsTrue (TestBag.FullDescription ().Contains("baked potato" + "\t" + "A baked potato potato." + "\n"));
			Assert.IsTrue (TestBag.FullDescription ().Contains("baked chicken" + "\t" + "A baked chicken chicken." + "\n"));
		}

		[Test()]
		public void BagBagTest()
		{
			Bag b1 = new Bag (new string[] { "b1", "Bag" }, "Test Bag", "A Testing Bag");
			Bag b2 = new Bag (new string[] { "b2", "Bag" }, "b2 Bag", "A Testing Bag");

			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");
			Item TestItem2 = new Item (new string[] { "chicken", "baked" }, "baked chicken", "a baked chicken");

			b1.Inventory.PutItem (TestItem);
			b2.Inventory.PutItem (TestItem2);
			b1.Inventory.PutItem (b2);

			Assert.IsTrue (b1.Locate ("potato") == TestItem);
			Assert.IsFalse (b1.Locate ("chicken") == TestItem2);
			Assert.IsTrue (b1.Locate ("b2") == b2);

		}

	}
}

