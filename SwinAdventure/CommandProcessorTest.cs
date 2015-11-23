using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace SwinAdventure
{
	[TestFixture()]
	public class CommandProcessorTest
	{
		
		public CommandProcessorTest ()
		{
		}

		[Test()]
		public void LookTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");

			LookCommand TestLook = new LookCommand ();

			CommandProcessor TestProcessor = new CommandProcessor ();

			TestProcessor.AddCommand (TestLook);

			Console.WriteLine(TestProcessor.Execute(TestPlayer, new string[3] {"look", "at", "me"}) );

			Assert.IsTrue (TestProcessor.Execute (TestPlayer, new string[3] {"look", "at", "me"}) == TestPlayer.LongDesc);
		}

		[Test()]
		public void MoveTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");
			Location TestLocation = new Location (new string[] { "potato", "farm" }, "potato farm", "a potato farm");
			Location TestLocation2 = new Location (new string[] { "melon", "farm" }, "melon farm", "a melon farm");
			Location TestLocation3 = new Location (new string[] { "tomato", "farm" }, "tomato farm", "a tomato farm");

			Path TestPath = new Path(new string[] { "potato", "path" });
			Path TestPath2 = new Path(new string[] { "melon", "path" });
			Path TestPath3 = new Path(new string[] { "tomato", "path" });


			TestLocation.Path = TestPath;
			TestPath.SetLocation('w', TestLocation2);
			TestPath.SetLocation('n', TestLocation3);

			TestLocation2.Path = TestPath2;
			TestPath2.SetLocation('e', TestLocation);
			TestPath2.SetLocation('a', TestLocation3);

			TestLocation3.Path = TestPath3;
			TestPath3.SetLocation('s', TestLocation);
			TestPath3.SetLocation('d', TestLocation2);

			TestPlayer.Location = TestLocation;


			MoveCommand TestMove = new  MoveCommand ();
			CommandProcessor TestProcessor = new CommandProcessor ();

			TestProcessor.AddCommand (TestMove);

			Assert.IsTrue (TestProcessor.Execute (TestPlayer, new string[3] {"move", "to","west"}) == TestLocation2.LongDesc);
			Assert.IsTrue (TestProcessor.Execute (TestPlayer, new string[3] {"move", "to","north_east"}) == TestLocation3.LongDesc);
		}

		[Test()]
		public void MultipleCommandTest()
		{
			Player TestPlayer = new Player ("TestPlayer", "For testing");
			Location TestLocation = new Location (new string[] { "potato", "farm" }, "potato farm", "a potato farm");
			Location TestLocation2 = new Location (new string[] { "melon", "farm" }, "melon farm", "a melon farm");
			Location TestLocation3 = new Location (new string[] { "tomato", "farm" }, "tomato farm", "a tomato farm");

			Path TestPath = new Path(new string[] { "potato", "path" });
			Path TestPath2 = new Path(new string[] { "melon", "path" });
			Path TestPath3 = new Path(new string[] { "tomato", "path" });


			TestLocation.Path = TestPath;
			TestPath.SetLocation('w', TestLocation2);
			TestPath.SetLocation('n', TestLocation3);

			TestLocation2.Path = TestPath2;
			TestPath2.SetLocation('e', TestLocation);
			TestPath2.SetLocation('a', TestLocation3);

			TestLocation3.Path = TestPath3;
			TestPath3.SetLocation('s', TestLocation);
			TestPath3.SetLocation('d', TestLocation2);

			TestPlayer.Location = TestLocation;


			MoveCommand TestMove = new  MoveCommand ();
			LookCommand TestLook = new LookCommand ();
			CommandProcessor TestProcessor = new CommandProcessor ();

			TestProcessor.AddCommand (TestMove);

			TestProcessor.AddCommand (TestLook);

			Assert.IsTrue (TestProcessor.Execute (TestPlayer, new string[3] {"look", "at", "me"}) == TestPlayer.LongDesc);
			Assert.IsTrue (TestProcessor.Execute (TestPlayer, new string[3] {"move", "to","west"}) == TestLocation2.LongDesc);
			Assert.IsTrue (TestProcessor.Execute (TestPlayer, new string[3] {"move", "to","north_east"}) == TestLocation3.LongDesc);
		}
	}
}

