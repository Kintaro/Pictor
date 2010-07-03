using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public static class MatrixPivot
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="a1">
		/// A <see cref="System.Double[,]"/>
		/// </param>
		/// <param name="a1Index0">
		/// A <see cref="System.UInt32"/>
		/// </param>
		/// <param name="a2">
		/// A <see cref="System.Double[,]"/>
		/// </param>
		/// <param name="a2Index0">
		/// A <see cref="System.UInt32"/>
		/// </param>
		static void SwapArraysIndex1 (double[,] a1, uint a1Index0, double[,] a2, uint a2Index0)
		{
			int Cols = a1.GetLength (1);
			if (a2.GetLength (1) != Cols) {
				throw new System.FormatException ("a1 and a2 must have the same second dimension.");
			}
			for (int i = 0; i < Cols; i++) {
				double tmp = a1[a1Index0, i];
				a1[a1Index0, i] = a2[a2Index0, i];
				a2[a2Index0, i] = tmp;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="m">
		/// A <see cref="System.Double[,]"/>
		/// </param>
		/// <param name="row">
		/// A <see cref="System.UInt32"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/>
		/// </returns>
		public static int Pivot (double[,] m, uint row)
		{
			int k = (int)(row);
			double max_val, tmp;
			
			max_val = -1.0;
			int i;
			int Rows = m.GetLength (0);
			for (i = (int)row; i < Rows; i++) {
				if ((tmp = Math.Abs (m[i, row])) > max_val && tmp != 0.0) {
					max_val = tmp;
					k = i;
				}
			}
			
			if (m[k, row] == 0.0) {
				return -1;
			}
			
			if (k != (int)(row)) {
				SwapArraysIndex1 (m, (uint)k, m, row);
				return k;
			}
			return 0;
		}
	}
}

