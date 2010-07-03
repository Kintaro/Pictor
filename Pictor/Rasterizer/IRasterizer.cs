using System;
using Pictor.Gamma;
using Pictor.VertexSource;
namespace Pictor.Rasterizer
{
	/// <summary>
	/// 
	/// </summary>
	public interface IRasterizer
	{
		/// <summary>
		/// 
		/// </summary>
		int MinX { get; }
		/// <summary>
		/// 
		/// </summary>
		int MinY { get; }
		/// <summary>
		/// 
		/// </summary>
		int MaxX { get; }
		/// <summary>
		/// 
		/// </summary>
		int MaxY { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="gamma_function">
		/// A <see cref="IGammaFunction"/>
		/// </param>
		void Gamma (IGammaFunction gammaFunction);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sl">
		/// A <see cref="IScanlineCache"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		bool SweepScanline (IScanlineCache sl);
		/// <summary>
		/// 
		/// </summary>
		void Reset ();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="vs">
		/// A <see cref="IVertexSource"/>
		/// </param>
		void AddPath (IVertexSource vs);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="vs">
		/// A <see cref="IVertexSource"/>
		/// </param>
		/// <param name="path_id">
		/// A <see cref="System.Int32"/>
		/// </param>
		void AddPath (IVertexSource vs, int path_id);
		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		bool RewindScanlines ();
	}
}

