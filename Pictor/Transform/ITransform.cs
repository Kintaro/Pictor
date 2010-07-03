using System;
namespace Pictor.Transform
{
	/// <summary>
	/// 
	/// </summary>
	public interface ITransform
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		void Transform (ref double x, ref double y);
	}
}

