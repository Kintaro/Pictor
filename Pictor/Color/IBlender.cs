using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public interface IBlender
	{
		/// <summary>
		/// 
		/// </summary>
		int NumPixelBits { get; }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="bufferOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="RGBA_Bytes"/>
		/// </returns>
		RgbaBytes PixelToColorRgbaBytes (byte[] buffer, int bufferOffset);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="bufferOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		/// <param name="count">
		/// A <see cref="System.Int32"/>
		/// </param>
		void CopyPixels (byte[] buffer, int bufferOffset, RgbaBytes sourceColor, int count);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="bufferOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		void BlendPixel (byte[] buffer, int bufferOffset, RgbaBytes sourceColor);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="bufferOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColors">
		/// A <see cref="RGBA_Bytes[]"/>
		/// </param>
		/// <param name="sourceColorsOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceCovers">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="sourceCoversOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="firstCoverForAll">
		/// A <see cref="System.Boolean"/>
		/// </param>
		/// <param name="count">
		/// A <see cref="System.Int32"/>
		/// </param>
		void BlendPixels (byte[] buffer, int bufferOffset, RgbaBytes[] sourceColors, int sourceColorsOffset, byte[] sourceCovers, int sourceCoversOffset, bool firstCoverForAll, int count);
	}
}

