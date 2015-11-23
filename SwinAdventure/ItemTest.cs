using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture()]
	public class ItemTest
	{
		public ItemTest ()
		{
		}

		[Test()]
		public void TestItemID()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");


			Assert.IsTrue (TestItem.AreYou ("potato"));
			Assert.IsTrue (TestItem.AreYou ("baked"));
		}

		[Test()]
		public void TestShortDescription()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");

			Assert.IsTrue (TestItem.ShortDesc == ("A baked potato potato."));
		}

		[Test()]
		public void TestLongDescription()
		{
			Item TestItem = new Item (new string[] { "potato", "baked" }, "baked potato", "a baked potato");

			Assert.IsTrue (TestItem.LongDesc == ("a baked potato"));
		}
	}
}

