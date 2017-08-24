using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisLibrary;
using System.Drawing;

namespace TetrisTests
{
	[TestClass]
	public class ShapeITests
	{
		[TestMethod]
		public void ShapeI_Constructor()
		{
			//assign
			IBoard board = new TestBoard();
			Shape i = new ShapeI(board);
			//act
			i.MoveDown();
			i.Rotate();
			i.Rotate();
			//assert
			Assert.AreEqual(new Point(5, 1), i[1].Position);
		}
	}
}
