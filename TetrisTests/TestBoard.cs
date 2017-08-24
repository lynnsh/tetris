using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary;
using Microsoft.Xna.Framework;

namespace TetrisTests
{
	//Test Board class that created a board with given size and colors.
	public class TestBoard : IBoard
	{
		private Color[,] board;

		public TestBoard(Color[,] b)
		{
			board = b;
		}

		public IShape Shape
		{
			get { throw new NotImplementedException(); }
		}

		public Color this[int i, int j]
		{
			get { return board[i,j]; }
		}

		public int GetLength(int rank)
		{
			return board.GetLength(rank);
		}

		public event GameOverHandle GameOver;

		public event LinesClearedHandle LinesCleared;

		public void OnLinesCleared(int lines)
		{
			if (LinesCleared != null)
				LinesCleared(lines);
		}

	}
}
