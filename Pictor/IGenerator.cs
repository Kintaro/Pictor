using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public interface IGenerator
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path_id">
		/// A <see cref="System.Int32"/>
		/// </param>
		void Rewind (int path_id);
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
		Path.FlagsAndCommand Vertex (ref double x, ref double y);

		/// <summary>
		/// 
		/// </summary>
		MathStroke.LineCap LineCap { get; set; }
		/// <summary>
		/// 
		/// </summary>
		MathStroke.LineJoin LineJoin { get; set; }
		/// <summary>
		/// 
		/// </summary>
		MathStroke.InnerJoin InnerJoin { get; set; }
		/// <summary>
		/// 
		/// </summary>
		double Width { get; set; }
		/// <summary>
		/// 
		/// </summary>
		double MiterLimit { get; set; }
		/// <summary>
		/// 
		/// </summary>
		double MiterLimitTheta { set; }
		/// <summary>
		/// 
		/// </summary>
		double InnerMiterLimit { get; set; }
		/// <summary>
		/// 
		/// </summary>
		double ApproximationScale { get; set; }
		/// <summary>
		/// 
		/// </summary>
		double Shorten { get; set; }
	}
}

