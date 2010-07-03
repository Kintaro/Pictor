using System;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public interface IImageFloat
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
		int StrideInfloats {get; }
		/// <summary>
		/// 
		/// </summary>
		int StrideInfloatsAbs { get; }
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
		/// A <see cref="System.float[]"/>
		/// </returns>
		float[] GetBuffer (out int bufferOffset);
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
		/// A <see cref="System.float[]"/>
		/// </returns>
		float[] GetPixelPointerY (int y, out int bufferOffset);
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
		/// A <see cref="System.float[]"/>
		/// </returns>
		float[] GetPixelPointerXY (int x, int y, out int bufferOffset);
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
		/// A <see cref="RgbaFloats"/>
		/// </returns>
		RgbaFloats Pixel (int x, int y);
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
		/// A <see cref="System.float[]"/>
		/// </param>
		/// <param name="floatOffset">
		/// A <see cref="System.Int32"/>
		/// </param>
		void CopyPixel (int x, int y, float[] c, int floatOffset);
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
		/// A <see cref="System.float[]"/>
		/// </param>
		/// <param name="colorToGet">
		/// A <see cref="IColorType"/>
		/// </param>
		void SetPixelFromColor (float[] pixelToSet, IColorType colorToGet);
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
		/// A <see cref="RgbaFloats"/>
		/// </param>
		/// <param name="cover">
		/// A <see cref="System.float"/>
		/// </param>
		void BlendPixel (int x, int y, RgbaFloats sourceColor, float cover);
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
		/// A <see cref="RgbaFloats"/>
		/// </param>
		void CopyHorizontalLine (int x, int y, int len, RgbaFloats sourceColor);
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
		/// A <see cref="RgbaFloats"/>
		/// </param>
		void CopyVerticalLine (int x, int y, int len, RgbaFloats sourceColor);
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
		/// A <see cref="RgbaFloats"/>
		/// </param>
		/// <param name="cover">
		/// A <see cref="System.float"/>
		/// </param>
		void BlendHorizontalLine (int x, int y, int x2, RgbaFloats sourceColor, float cover);
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
		/// A <see cref="RgbaFloats"/>
		/// </param>
		/// <param name="cover">
		/// A <see cref="System.float"/>
		/// </param>
		void BlendVerticalLine (int x, int y1, int y2, RgbaFloats sourceColor, float cover);
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
		/// A <see cref="RgbaFloats[]"/>
		/// </param>
		/// <param name="colorIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		void CopyColorHorizontalSpan (int x, int y, int len, RgbaFloats[] colors, int colorIndex);
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
		/// A <see cref="RgbaFloats[]"/>
		/// </param>
		/// <param name="colorIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		void CopyColorVerticalSpan (int x, int y, int len, RgbaFloats[] colors, int colorIndex);
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
		/// A <see cref="RgbaFloats"/>
		/// </param>
		/// <param name="covers">
		/// A <see cref="System.float[]"/>
		/// </param>
		/// <param name="coversIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		void BlendSolidHorizontalSpan (int x, int y, int len, RgbaFloats sourceColor, float[] covers, int coversIndex);
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
		/// A <see cref="RgbaFloats"/>
		/// </param>
		/// <param name="covers">
		/// A <see cref="System.float[]"/>
		/// </param>
		/// <param name="coversIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		void BlendSolidVerticalSpan (int x, int y, int len, RgbaFloats sourceColor, float[] covers, int coversIndex);
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
		/// A <see cref="RgbaFloats[]"/>
		/// </param>
		/// <param name="colorsIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="covers">
		/// A <see cref="System.float[]"/>
		/// </param>
		/// <param name="coversIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="firstCoverForAll">
		/// A <see cref="System.Boolean"/>
		/// </param>
		void BlendColorHorizontalSpan (int x, int y, int len, RgbaFloats[] colors, int colorsIndex, float[] covers, int coversIndex, bool firstCoverForAll);
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
		/// A <see cref="RgbaFloats[]"/>
		/// </param>
		/// <param name="colorsIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="covers">
		/// A <see cref="System.float[]"/>
		/// </param>
		/// <param name="coversIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="firstCoverForAll">
		/// A <see cref="System.Boolean"/>
		/// </param>
		void BlendColorVerticalSpan (int x, int y, int len, RgbaFloats[] colors, int colorsIndex, float[] covers, int coversIndex, bool firstCoverForAll);
	}
}

