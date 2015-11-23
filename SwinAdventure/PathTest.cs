using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture()]
	public class PathTest
	{
		
		public PathTest ()
		{
		}

		[Test()]
		public void PathMoveTest()
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

			Assert.IsTrue (TestMove.Execute (TestPlayer, new string[3] {"move", "to","west"}) == TestLocation2.LongDesc);
			Assert.IsTrue (TestMove.Execute (TestPlayer, new string[3] {"move", "to","north_east"}) == TestLocation3.LongDesc);

		}

		[Test()]
		public void GetPathTest()
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
			Assert.IsTrue (TestLocation.Path == TestPath);

		}

		[Test()]
		public void LeaveTest()
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

			Assert.IsTrue (TestMove.Execute (TestPlayer, new string[3] {"move", "to","west"}) == TestLocation2.LongDesc);
			Assert.IsTrue (TestMove.Execute (TestPlayer, new string[1] {"leave"}) == TestLocation.LongDesc);

		}

		[Test()]
		public void LeaveFailTest()
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

			Assert.IsTrue (TestMove.Execute (TestPlayer, new string[3] {"move", "to","heaven"}) == "path not found");
			Assert.IsTrue (TestMove.Execute (TestPlayer, new string[1] {"should fail"}) == "i don't know how to move like that");

		}
	}
}

