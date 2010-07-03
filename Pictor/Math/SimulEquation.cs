using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	struct SimulEquation
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="left">
		/// A <see cref="System.Double[,]"/>
		/// </param>
		/// <param name="right">
		/// A <see cref="System.Double[,]"/>
		/// </param>
		/// <param name="result">
		/// A <see cref="System.Double[,]"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public static bool Solve (double[,] left, double[,] right, double[,] result)
		{
			if (left.GetLength (0) != 4 || right.GetLength (0) != 4 || left.GetLength (1) != 4 || result.GetLength (0) != 4 || right.GetLength (1) != 2 || result.GetLength (1) != 2) {
				throw new System.FormatException ("left right and result must all be the same size.");
			}
			double a1;
			int Size = right.GetLength (0);
			int RightCols = right.GetLength (1);
			
			double[,] tmp = new double[Size, Size + RightCols];
			
			for (int i = 0; i < Size; i++) {
				for (int j = 0; j < Size; j++) {
					tmp[i, j] = left[i, j];
				}
				for (int j = 0; j < RightCols; j++) {
					tmp[i, Size + j] = right[i, j];
				}
			}
			
			for (int k = 0; k < Size; k++) {
				if (MatrixPivot.Pivot (tmp, (uint)k) < 0) {
					return false;
					// Singularity....
				}
				
				a1 = tmp[k, k];
				
				for (int j = k; j < Size + RightCols; j++) {
					tmp[k, j] /= a1;
				}
				
				for (int i = k + 1; i < Size; i++) {
					a1 = tmp[i, k];
					for (int j = k; j < Size + RightCols; j++) {
						tmp[i, j] -= a1 * tmp[k, j];
					}
				}
			}
			
			
			for (int k = 0; k < RightCols; k++) {
				int m;
				for (m = (int)(Size - 1); m >= 0; m--) {
					result[m, k] = tmp[m, Size + k];
					for (int j = m + 1; j < Size; j++) {
						result[m, k] -= tmp[m, j] * result[j, k];
					}
				}
			}
			return true;
		}
	}
}

