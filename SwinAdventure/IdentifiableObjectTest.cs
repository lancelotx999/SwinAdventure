using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture()]
	public class IdentifiableObjectTest
	{
		public IdentifiableObjectTest ()
		{
		}

		[Test()]
		public void TestCreation()
		{
			IdentifiableObject TestObject = new IdentifiableObject (new string[] {"potato", "apple"});

			Assert.IsTrue (TestObject.FirstId == "potato");
		}

		[Test()]
		public void TestAreYou()
		{
			IdentifiableObject TestObject = new IdentifiableObject (new string[] {"fred", "bob"});

			Assert.IsTrue (TestObject.AreYou("fred"));
			Assert.IsTrue (TestObject.AreYou("bob"));
			Assert.IsFalse (TestObject.AreYou("wilma"));
			Assert.IsFalse (TestObject.AreYou("boby"));
			Assert.IsFalse (TestObject.AreYou("Fred"));
			Assert.IsFalse (TestObject.AreYou("BOB"));
		}

		[Test()]
		public void TestFirstID()
		{
			IdentifiableObject TestObject = new IdentifiableObject (new string[] {"fred", "bob"});

			Assert.IsTrue (TestObject.FirstId == "fred");
		}

		[Test()]
		public void TestAddID()
		{
			IdentifiableObject TestObject = new IdentifiableObject (new string[] {"fred", "bob"});

			TestObject.AddIdentifier ("wilma");

			Assert.IsTrue (TestObject.AreYou("fred"));
			Assert.IsTrue (TestObject.AreYou("bob"));
			Assert.IsTrue (TestObject.AreYou("wilma"));
		}
	}
}

