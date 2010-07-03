using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public interface IVertexDest
	{
		/// <summary>
		/// 
		/// </summary>
		void RemoveAll ();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="vertex">
		/// A <see cref="Vector2D"/>
		/// </param>
		void Add (Vector2D vertex);
		/// <summary>
		/// 
		/// </summary>
		int Size { get; }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="i">
		/// A <see cref="System.Int32"/>
		/// </param>
		Vector2D this[int i] { get;	}
	}
}

