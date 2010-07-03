using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public static class PictorBasics
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/>
		/// </returns>
		public static int Uround (double v)
		{
			return (int)(uint)(v + 0.5);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="v1">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="v2">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="epsilon">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public static bool IsEqualEpsilon (double v1, double v2, double epsilon)
		{
			return Math.Abs (v1 - v2) <= (double)(epsilon);
		}
	}
}

