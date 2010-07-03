using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public class MathStroke
	{
		/// <summary>
		/// 
		/// </summary>
		public enum LineCap
		{
			/// <summary>
			/// 
			/// </summary>
			Butt,
			/// <summary>
			/// 
			/// </summary>
			Square,
			/// <summary>
			/// 
			/// </summary>
			Round
		}

		/// <summary>
		/// 
		/// </summary>
		public enum LineJoin
		{
			/// <summary>
			/// 
			/// </summary>
			Miter = 0,
			/// <summary>
			/// 
			/// </summary>
			MiterRevert = 1,
			/// <summary>
			/// 
			/// </summary>
			RoundJoin = 2,
			/// <summary>
			/// 
			/// </summary>
			BevelJoin = 3,
			/// <summary>
			/// 
			/// </summary>
			MiterRound = 4
		}

		/// <summary>
		/// 
		/// </summary>
		public enum InnerJoin
		{
			/// <summary>
			/// 
			/// </summary>
			Bevel,
			/// <summary>
			/// 
			/// </summary>
			Miter,
			/// <summary>
			/// 
			/// </summary>
			Jag,
			/// <summary>
			/// 
			/// </summary>
			Round
		}
	}
}

