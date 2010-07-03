using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public interface IScanlineCache
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		void Finalize (int y);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="min_x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="max_x">
		/// A <see cref="System.Int32"/>
		/// </param>
		void Reset (int min_x, int max_x);
		/// <summary>
		/// 
		/// </summary>
		void ResetSpans ();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="cover">
		/// A <see cref="System.Int32"/>
		/// </param>
		void AddCell (int x, int cover);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="cover">
		/// A <see cref="System.Int32"/>
		/// </param>
		void AddSpan (int x, int len, int cover);

		/// <summary>
		/// 
		/// </summary>
		int NumberOfSpans { get; }
		/// <summary>
		/// 
		/// </summary>
		ScanlineSpan Begin { get; }
		/// <summary>
		/// 
		/// </summary>
		ScanlineSpan NextScanlineSpan { get; }
		/// <summary>
		/// 
		/// </summary>
		int y { get; }
		/// <summary>
		/// 
		/// </summary>
		byte[] Covers { get; }
	}
}

