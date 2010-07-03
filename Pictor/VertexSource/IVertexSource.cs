using System;
namespace Pictor.VertexSource
{
	/// <summary>
	/// 
	/// </summary>
	public interface IVertexSource
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pathId">
		/// A <see cref="System.Int32"/>
		/// </param>
		void Rewind (int pathId);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="Path.FlagsAndCommand"/>
		/// </returns>
		Path.FlagsAndCommand Vertex (out double x, out double y);
	}
}

