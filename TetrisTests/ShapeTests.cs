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
	 //Most shapes are using Shape class methods,
	//thus they do not need to be tested separately, except for the rotate method.
	[TestClass]
	public class ShapeTests
	{
		[TestMethod]
		public void BlockProperty_Return()
		{
			//arrange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeI(board);

			//act
			try
			{
				Block b = shape[-1];
				//arrange
				Assert.Fail();
			}
			catch (IndexOutOfRangeException e)
			{ }
		}

		[TestMethod]
		public void Drop_EnoughSpace_EmptyBoard()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeI(board);

			//act
			shape.Drop();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(4, x); //expected, actual
			Assert.AreEqual(9, y);
		}

		[TestMethod]
		public void Drop_EnoughSpace_BoardWithLine()
		{
			//arange
			IBoard board = new TestBoard(createBoardWithLineHor());
			IShape shape = new ShapeI(board);

			//act
			shape.Drop();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(4, x); //expected, actual
			Assert.AreEqual(8, y);
		}

		[TestMethod]
		public void Drop_NoSpace_EmptyBoard()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 1));
			IShape shape = new ShapeI(board);

			//act
			shape.Drop();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(4, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		public void MoveDown_EnoughSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeI(board);

			//act
			shape.MoveDown();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(4, x); //expected, actual
			Assert.AreEqual(1, y);
		}

		[TestMethod]
		public void MoveDown_NoSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 1));
			IShape shape = new ShapeI(board);

			//act
			shape.MoveDown();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(4, x); //expected, actual
			Assert.AreEqual(0, y);
		}


		[TestMethod]
		public void MoveLeft_EnoughSpace_EmptyBoard()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeI(board);

			//act
			shape.MoveLeft();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(3, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		public void MoveLeft_NoSpace_BoardWithLine()
		{
			//arange
			IBoard board = new TestBoard
				(createBoardWithLineVert(3, 1, (i => i < 10)));
			IShape shape = new ShapeI(board);

			//act
			shape.MoveLeft();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(4, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		public void MoveLeft_NoSpace_EmptyBoard()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 1));
			IShape shape = new ShapeI(board);

			//act
			shape.MoveLeft();
			shape.MoveLeft();
			shape.MoveLeft();
			shape.MoveLeft();
			shape.MoveLeft();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(0, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		public void MoveRight_EnoughSpace_EmptyBoard()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeI(board);

			//act
			shape.MoveRight();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(5, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		//test with shapeZ to verify multi-line shapes
		public void MoveRight_NoSpace_BoardWithLine()
		{
			//arange
			IBoard board = new TestBoard
				(createBoardWithLineVert(8, -1, (i => i >= 0)));
			IShape shape = new ShapeZ(board);

			//act
			shape.MoveRight();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(5, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		//test with shapeZ to verify multi-line shapes
		public void MoveRight_NoSpace_EmptyBoard()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(8, 10));
			IShape shape = new ShapeZ(board);

			//act
			shape.MoveRight();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(5, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		public void Rotate_ShapeO()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeO(board);

			//act
			shape.Rotate();
			int x = shape[0].Position.X;
			int y = shape[0].Position.Y;

			//assert
			Assert.AreEqual(5, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		public void Rotate_ShapeI_EnoughSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeI(board);

			//act
			shape.MoveDown();
			shape.Rotate();
			int x1 = shape[3].Position.X;
			int y1 = shape[3].Position.Y;
			shape.Rotate();
			int x2 = shape[3].Position.X;
			int y2 = shape[3].Position.Y;
			shape.Rotate();
			int x3 = shape[3].Position.X;
			int y3 = shape[3].Position.Y;

			//assert
			Assert.AreEqual(6, x1); //expected, actual
			Assert.AreEqual(0, y1);
			Assert.AreEqual(7, x2); //expected, actual
			Assert.AreEqual(1, y2);
			Assert.AreEqual(6, x1); //expected, actual
			Assert.AreEqual(0, y1);
		}

		[TestMethod]
		public void Rotate_ShapeI_NoSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeI(board);

			//act
			shape.Rotate();
			int x = shape[3].Position.X;
			int y = shape[3].Position.Y;

			//assert
			Assert.AreEqual(7, x); //expected, actual
			Assert.AreEqual(0, y);
		}

		[TestMethod]
		public void Rotate_ShapeJ()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeJ(board);

			//act
			Point[] arr = rotate(shape);

			//assert
			Assert.AreEqual(6, arr[0].X); //expected, actual
			Assert.AreEqual(2, arr[0].Y);

			Assert.AreEqual(7, arr[1].X);
			Assert.AreEqual(1, arr[1].Y);

			Assert.AreEqual(6, arr[2].X);
			Assert.AreEqual(0, arr[2].Y);

			Assert.AreEqual(5, arr[3].X);
			Assert.AreEqual(1, arr[3].Y);
		}

		[TestMethod]
		public void Rotate_ShapeL()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeL(board);

			//act
			Point[] arr = rotate(shape);

			//assert
			Assert.AreEqual(6, arr[0].X); //expected, actual
			Assert.AreEqual(0, arr[0].Y);

			Assert.AreEqual(5, arr[1].X);
			Assert.AreEqual(1, arr[1].Y);

			Assert.AreEqual(6, arr[2].X);
			Assert.AreEqual(2, arr[2].Y);

			Assert.AreEqual(7, arr[3].X);
			Assert.AreEqual(1, arr[3].Y);
		}

		[TestMethod]
		public void Rotate_ShapeS()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeS(board);

			//act
			shape.MoveDown();
			shape.Rotate();
			int x1 = shape[2].Position.X;
			int y1 = shape[2].Position.Y;
			shape.Rotate();
			int x2 = shape[2].Position.X;
			int y2 = shape[2].Position.Y;

			//assert
			Assert.AreEqual(7, x1); //expected, actual
			Assert.AreEqual(2, y1);
			Assert.AreEqual(5, x2); //expected, actual
			Assert.AreEqual(2, y2);
		}

		[TestMethod]
		public void Rotate_ShapeT()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeT(board);

			//act
			Point[] arr = rotate(shape);

			//assert
			Assert.AreEqual(7, arr[0].X); //expected, actual
			Assert.AreEqual(1, arr[0].Y);

			Assert.AreEqual(6, arr[1].X);
			Assert.AreEqual(0, arr[1].Y);

			Assert.AreEqual(5, arr[2].X);
			Assert.AreEqual(1, arr[2].Y);

			Assert.AreEqual(6, arr[3].X);
			Assert.AreEqual(2, arr[3].Y);
		}

		[TestMethod]
		public void Rotate_ShapeZ()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeZ(board);

			//act
			shape.MoveDown();
			shape.Rotate();
			int x1 = shape[0].Position.X;
			int y1 = shape[0].Position.Y;
			shape.Rotate();
			int x2 = shape[0].Position.X;
			int y2 = shape[0].Position.Y;

			//assert
			Assert.AreEqual(6, x1); //expected, actual
			Assert.AreEqual(2, y1);
			Assert.AreEqual(5, x2); //expected, actual
			Assert.AreEqual(1, y2);
		}

		[TestMethod]
		public void Move_OnJoinPile()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard(10, 10));
			IShape shape = new ShapeI(board);

			bool eventJoin = false;
			shape.JoinPile += () => eventJoin = true;
			//act
			shape.Drop();

			//assert
			Assert.IsTrue(eventJoin);
		}

		private Point[] rotate(IShape shape)
		{
			Point[] a = new Point[4];
			shape.MoveDown();
			shape.Rotate();
			a[0] = new Point(shape[3].Position.X, shape[3].Position.Y);
			shape.Rotate();
			a[1] = new Point(shape[3].Position.X, shape[3].Position.Y);
			shape.Rotate();
			a[2] = new Point(shape[3].Position.X, shape[3].Position.Y);
			shape.Rotate();
			a[3] = new Point(shape[3].Position.X, shape[3].Position.Y);
			return a;
		}

		private Color[,] createEmptyBoard(int x, int y)
		{
			Color[,] array = new Color[x, y];
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
					array[i, j] = new Color(20, 20, 20);
			}
			return array;
		}

		private Color[,] createBoardWithLineHor()
		{
			Color[,] array = new Color[10, 10];
			for (int i = 0; i < array.GetLength(0); i++)
			{
				array[i, 9] = Color.Purple;
			}
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 9; j++)
					array[i, j] = new Color(20, 20, 20);
			}
			return array;
		}

		//x - column that should be coloured
		//incr - for loop increment
		//f - predicate
		private Color[,] createBoardWithLineVert(int colColour, int incr, Function f)
		{
			Color[,] array = new Color[10, 10];
			for (int j = 0; j < array.GetLength(1); j++)
			{
				array[colColour, j] = Color.Purple;
			}

			for (int i = colColour+incr; f(i); i += incr)
			{
				for (int j = 0; j < 10; j++)
					array[i, j] = new Color(20, 20, 20);
			}
			return array;
		}
	}

	public delegate bool Function(int x);
}
