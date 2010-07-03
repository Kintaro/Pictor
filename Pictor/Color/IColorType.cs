using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public interface IColorType
	{
		/// <summary>
		/// 
		/// </summary>
		RgbaDoubles AsRgbaDoubles { get; }
		RgbaFloats AsRgbaFloats { get; }
		RgbaBytes AsRgbaBytes { get; }
		
		/// <summary>
		/// 
		/// </summary>
		int r { get; set; }
		/// <summary>
		/// 
		/// </summary>
		int g { get; set; }
		/// <summary>
		/// 
		/// </summary>
		int b { get; set; }
		/// <summary>
		/// 
		/// </summary>
		int a { get; set; }
	}
}

