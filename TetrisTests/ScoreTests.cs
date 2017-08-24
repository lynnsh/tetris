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
	public class ScoreTests
	{
		[TestMethod]
		public void CalculateScore_LessThan4Lines()
		{
			//arrange
			IBoard board = new TestBoard(createEmptyBoard());
			Score score = new Score(board);

			//act
			((TestBoard)board).OnLinesCleared(2);
			int scoreVal = score.ScoreValue;
			int lines = score.Lines;

			//assert
			Assert.AreEqual(200, scoreVal);
			Assert.AreEqual(2, lines);
		}

		[TestMethod]
		public void CalculateScore_MoreThan4Lines()
		{
			//arrange
			IBoard board = new TestBoard(createEmptyBoard());
			Score score = new Score(board);

			//act
			((TestBoard)board).OnLinesCleared(9);
			int scoreVal = score.ScoreValue;

			//assert
			Assert.AreEqual(1700, scoreVal);
		}

		[TestMethod]
		public void CalculateLevel_LessThan100Lines()
		{
			//arrange
			IBoard board = new TestBoard(createEmptyBoard());
			Score score = new Score(board);

			//act
			((TestBoard)board).OnLinesCleared(15);
			int level = score.Level;

			//assert
			Assert.AreEqual(2, level);
		}

		[TestMethod]
		public void CalculateLevel_MoreThan100Lines()
		{
			//arrange
			IBoard board = new TestBoard(createEmptyBoard());
			Score score = new Score(board);

			//act
			for (int i = 0; i < 9; i++)
				((TestBoard)board).OnLinesCleared(15);

			int level = score.Level;
			int lines = score.Lines;

			//assert
			Assert.AreEqual(10, level);
			Assert.AreEqual(135, lines);
		}

		private Color[,] createEmptyBoard()
		{
			Color[,] array = new Color[10, 20];
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
					array[i, j] = new Color(20, 20, 20);
			}
			return array;
		}
	}
}
