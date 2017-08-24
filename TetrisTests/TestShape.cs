using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary;
using Microsoft.Xna.Framework;

namespace TetrisTests
{
	//Test Shape class that creates a horizontal linerar shape of any size. Rotation is not supported.
	public class TestShape : Shape
	{

		public TestShape(IBoard board, int size) : base(board, setBlocks(board, size), null)
		{}

		public override void Rotate()
		{ }

		private static Block[] setBlocks(IBoard board, int size)
		{
			Block[] blocks = new Block[size];
			for (int i = 0; i < size; i++)
				blocks[i] = new Block(board, Color.BlueViolet, new Point(i, 0));
			return blocks;
		}
	}
}
