using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public interface IImage
	{
		/// <summary>
		/// 
		/// </summary>
		Vector2D OriginOffset { get; set; }
		/// <summary>
		/// 
		/// </summary>
		int Width { get; }
		/// <summary>
		/// 
		/// </summary>
		int Height {get; }
		/// <summary>
		/// 
		/// </summary>
		int StrideInBytes {get; }
		/// <summary>
		/// 
		/// </summary>
		int StrideInBytesAbs { get; }
		/// <summary>
		/// 
		/// </summary>
		RectI GetBounds {get;}
		/// <summary>
		/// 
		/// </summary>
		IBlender Blender { get; set; }
		/// <summary>
		/// 
		/// </summary>
		int DistanceBetweenPixelsInclusive { get; }
		/// <summary>
		/// 
		/// </summary>
		int BitDepth { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="RendererBase"/>
		/// </returns>
		RendererBase NewRenderer ();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="bufferOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Byte[]"/>
		/// </returns>
		byte[] GetBuffer (out int bufferOffset);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="bufferOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Byte[]"/>
		/// </returns>
		byte[] GetPixelPointerY (int y, out int bufferOffset);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="bufferOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Byte[]"/>
		/// </returns>
		byte[] GetPixelPointerXY (int x, int y, out int bufferOffset);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="RGBA_Bytes"/>
		/// </returns>
		RgbaBytes Pixel (int x, int y);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="c">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="ByteOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		void CopyPixel (int x, int y, byte[] c, int ByteOffset);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sourceImage">
		/// A <see cref="IImage"/>
		/// </param>
		void CopyFrom (IImage sourceImage);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sourceImage">
		/// A <see cref="IImage"/>
		/// </param>
		/// <param name="sourceImageRect">
		/// A <see cref="RectI"/>
		/// </param>
		/// <param name="destXOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="destYOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		void CopyFrom (IImage sourceImage, RectI sourceImageRect, int destXOffset, int destYOffset);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pixelToSet">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="colorToGet">
		/// A <see cref="IColorType"/>
		/// </param>
		void SetPixelFromColor (byte[] pixelToSet, IColorType colorToGet);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		/// <param name="cover">
		/// A <see cref="System.Byte"/>
		/// </param>
		void BlendPixel (int x, int y, RgbaBytes sourceColor, byte cover);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		void CopyHorizontalLine (int x, int y, int len, RgbaBytes sourceColor);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		void CopyVerticalLine (int x, int y, int len, RgbaBytes sourceColor);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="x2">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		/// <param name="cover">
		/// A <see cref="System.Byte"/>
		/// </param>
		void BlendHorizontalLine (int x, int y, int x2, RgbaBytes sourceColor, byte cover);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y1">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y2">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		/// <param name="cover">
		/// A <see cref="System.Byte"/>
		/// </param>
		void BlendVerticalLine (int x, int y1, int y2, RgbaBytes sourceColor, byte cover);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="colors">
		/// A <see cref="RGBA_Bytes[]"/>
		/// </param>
		/// <param name="colorIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		void CopyColorHorizontalSpan (int x, int y, int len, RgbaBytes[] colors, int colorIndex);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="colors">
		/// A <see cref="RGBA_Bytes[]"/>
		/// </param>
		/// <param name="colorIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		void CopyColorVerticalSpan (int x, int y, int len, RgbaBytes[] colors, int colorIndex);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		/// <param name="covers">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="coversIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		void BlendSolidHorizontalSpan (int x, int y, int len, RgbaBytes sourceColor, byte[] covers, int coversIndex);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="sourceColor">
		/// A <see cref="RGBA_Bytes"/>
		/// </param>
		/// <param name="covers">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="coversIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		void BlendSolidVerticalSpan (int x, int y, int len, RgbaBytes sourceColor, byte[] covers, int coversIndex);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="colors">
		/// A <see cref="RGBA_Bytes[]"/>
		/// </param>
		/// <param name="colorsIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="covers">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="coversIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="firstCoverForAll">
		/// A <see cref="System.Boolean"/>
		/// </param>
		void BlendColorHorizontalSpan (int x, int y, int len, RgbaBytes[] colors, int colorsIndex, byte[] covers, int coversIndex, bool firstCoverForAll);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="len">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="colors">
		/// A <see cref="RGBA_Bytes[]"/>
		/// </param>
		/// <param name="colorsIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="covers">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="coversIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="firstCoverForAll">
		/// A <see cref="System.Boolean"/>
		/// </param>
		void BlendColorVerticalSpan (int x, int y, int len, RgbaBytes[] colors, int colorsIndex, byte[] covers, int coversIndex, bool firstCoverForAll);
	}
}

