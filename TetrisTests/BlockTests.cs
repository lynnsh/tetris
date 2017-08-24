using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using TetrisLibrary;

namespace TetrisTests
{
	[TestClass]
	public class BlockTests
	{
		[TestMethod]
		public void Constructor_WrongPosition()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());

			//act
			try 
			{ 
				Block b = new Block(board, Color.Beige, new Point(0, 5));
				//arrange
				Assert.Fail();
			}
			catch (ArgumentException e)
			{}
		}

		[TestMethod]
		public void MoveDown_EnoughSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			Block b = new Block(board, Color.Beige, new Point(0, 0));

			//act
			bool result = b.TryMoveDown();
			b.MoveDown();
			int y = b.Position.Y;
			int x = b.Position.X;
			
			//assert
			Assert.AreEqual(1, y); //expected, actual
			Assert.AreEqual(0, x);
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void MoveDown_NoSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			Block b = new Block(board, Color.Beige, new Point(0, 4));

			//act
			bool result = b.TryMoveDown();
			b.MoveDown();
			int y = b.Position.Y;
			int x = b.Position.X;

			//assert
			Assert.AreEqual(4, y); //expected, actual
			Assert.AreEqual(0, x);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void MoveLeft_EnoughSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			Block b = new Block(board, Color.Beige, new Point(1, 0));

			//act
			bool result = b.TryMoveLeft();
			b.MoveLeft();
			int x = b.Position.X;
			int y = b.Position.Y;

			//assert
			Assert.AreEqual(0, x); //expected, actual
			Assert.AreEqual(0, y);
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void MoveLeft_NoSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			Block b = new Block(board, Color.Beige, new Point(0, 0));

			//act
			bool result = b.TryMoveLeft();
			b.MoveLeft();
			int x = b.Position.X;
			int y = b.Position.Y;

			//assert
			Assert.AreEqual(0, x); //expected, actual
			Assert.AreEqual(0, y);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void MoveRight_EnoughSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			Block b = new Block(board, Color.Beige, new Point(0, 0));

			//act
			bool result = b.TryMoveRight();
			b.MoveRight();
			int x = b.Position.X;
			int y = b.Position.Y;

			//assert
			Assert.AreEqual(1, x); //expected, actual
			Assert.AreEqual(0, y);
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void MoveRight_NoSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			Block b = new Block(board, Color.Beige, new Point(4, 0));

			//act
			bool result = b.TryMoveRight();
			b.MoveRight();
			int x = b.Position.X;
			int y = b.Position.Y;

			//assert
			Assert.AreEqual(4, x); //expected, actual
			Assert.AreEqual(0, y);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void Rotate_EnoughSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			Block b = new Block(board, Color.Beige, new Point(1, 0));

			//act
			bool result = b.TryRotate(new Point(-1, 1));
			b.Rotate(new Point(-1,1));
			int x = b.Position.X;
			int y = b.Position.Y;

			//assert
			Assert.AreEqual(0, x); //expected, actual
			Assert.AreEqual(1, y);
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void Rotate_NoSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			Block b = new Block(board, Color.Beige, new Point(4, 0));

			//act
			bool result = b.TryRotate(new Point(1, 1));
			b.Rotate(new Point(1, 1));
			int x = b.Position.X;
			int y = b.Position.Y;

			//assert
			Assert.AreEqual(4, x); //expected, actual
			Assert.AreEqual(0, y);
			Assert.AreEqual(false, result);
		}

		private Color[,] createEmptyBoard()
		{
			Color[,] array = new Color[5, 5];
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
					array[i, j] = new Color(20, 20, 20);
			}
			return array;
		}

	}
}
