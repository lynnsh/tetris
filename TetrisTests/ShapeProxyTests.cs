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
	//Most move methods for Shape were tested in ShapeTests.
	public class ShapeProxyTests
	{
		[TestMethod]
		public void Move_OnJoinPile()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			IShape shape = new ShapeProxy(board);

			bool eventJoin = false;
			shape.JoinPile += () => eventJoin = true;
			//act
			shape.Drop();

			//assert
			Assert.IsTrue(eventJoin);
		}

		[TestMethod]
		public void DeployNewShape_DifferentShapeCreated()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			ShapeProxy shape = new ShapeProxy(board);

			//act
			shape.Drop();
			Block b1 = shape[0];
			shape.DeployNewShape();
			Block b2 = shape[0];

			//assert
			//Blocks should have different positions since belong two different shapes (and one of the was moved)
			Assert.IsFalse(b1.Position.Equals(b2.Position));
		}

		[TestMethod]
		public void DeployNewShape_WithArgument()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			ShapeProxy shape = new ShapeProxy(board);
			ShapeProxy shape2 = new ShapeProxy(board);

			//act
			shape.DeployNewShape(shape2);

			//assert
			//Blocks should have the same color since the shape created in shape2 is passed to shape
			Assert.IsTrue(shape[0].Colour.Equals(shape2[0].Colour));
		}

		[TestMethod]
		public void MoveDown_EnoughSpace()
		{
			//arange
			IBoard board = new TestBoard(createEmptyBoard());
			IShape shape = new ShapeProxy(board);

			//act
			int x1 = shape[0].Position.X;
			int y1 = shape[0].Position.Y;
			shape.MoveDown();
			int x2 = shape[0].Position.X;
			int y2 = shape[0].Position.Y;

			//assert
			Assert.IsTrue(x1 == x2);
			Assert.IsTrue(y1 != y2);
		}

		private Color[,] createEmptyBoard()
		{
			Color[,] array = new Color[10, 10];
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
					array[i, j] = new Color(20, 20, 20);
			}
			return array;
		}
	}
}
