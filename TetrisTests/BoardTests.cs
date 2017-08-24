using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using TetrisLibrary;
using System.Diagnostics;


namespace TetrisTests
{
	[TestClass]
	public class BoardTests
	{
		[TestMethod]
		public void IndexerGetter_InvalidCoord()
		{
			//arange
			IBoard board = new Board();

			//act
			try
			{
				Color c = board[-1, 1];
				//arrange
				Assert.Fail();
			}
			catch (IndexOutOfRangeException e)
			{ }
		}

		[TestMethod]
		public void GetLength_InvalidCoord()
		{
			//arange
			IBoard board = new Board();

			//act
			try
			{
				int i = board.GetLength(-1);
				//arrange
				Assert.Fail();
			}
			catch (IndexOutOfRangeException e)
			{ }
		}

		[TestMethod]
		public void GetLength_ValidCoord()
		{
			//arange
			IBoard board = new Board();

			//act
			int i = board.GetLength(1);
			
			//assert
			Assert.AreEqual(21, i); //expected, actual
		}

		[TestMethod]
		public void GameOver()
		{
			//arange
			IBoard board = new Board();
			bool eventGameOver = false;
			board.GameOver += () => eventGameOver = true;
			IShape shape = board.Shape;

			//act
			for (int i = 0; i < 10; i++)
			{
				shape.MoveDown();
				shape.Rotate();
				shape.Drop();
			}

			//assert
			Assert.IsTrue(eventGameOver);
		}

		//LinesCleared event cannot be tested because the ShapeProxy class is created in Board class,
        //so that it is impossible to create a TestShape class to verify this event.

		[TestMethod]
		public void AddToPileTest()
		{
			//arange
			IBoard board = new Board();
			IShape shape = board.Shape;
			bool found = false;

			//act
			Color c = shape[0].Colour;
			shape.Drop();

			for (int i = 0; i < 9 && !found; i++)
			{
				if (board[i, 20].Equals(c))
					found = true;
			}

			//assert
			Assert.IsTrue(found);
		}

		
	}
}
