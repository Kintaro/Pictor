using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public interface IMarkers
	{
		/// <summary>
		/// 
		/// </summary>
		void RemoveAll ();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="unknown">
		/// A <see cref="Path.FlagsAndCommand"/>
		/// </param>
		void AddVertex (double x, double y, Path.FlagsAndCommand unknown);
	}
}

