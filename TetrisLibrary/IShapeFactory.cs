using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
	/// <summary>
	/// Represents the factory used to create a new Shape.
	/// </summary>
	public interface IShapeFactory
	{
		/// <summary>
		/// Randomly creates a new Shape.
		/// </summary>
		void DeployNewShape();
	}
}
