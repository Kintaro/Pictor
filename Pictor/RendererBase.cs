using System.Collections.Generic;
using Pictor.Transform;
using Pictor.VertexSource;
using Pictor.Rasterizer;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class RendererBase
	{
		/// <summary>
		/// 
		/// </summary>
		const int CoverFull = 255;
		/// <summary>
		/// 
		/// </summary>
		protected IImage m_DestImage;
		/// <summary>
		/// 
		/// </summary>
		protected IImageFloat m_DestImageFloat;
		/// <summary>
		/// 
		/// </summary>
		protected GsvText TextPath;
		/// <summary>
		/// 
		/// </summary>
		protected ConvStroke StrockedText;
		/// <summary>
		/// 
		/// </summary>
		protected Stack<Affine> affineTransformStack = new Stack<Affine> ();
		/// <summary>
		/// 
		/// </summary>
		protected ScanlineRasterizer rasterizer;

		/// <summary>
		/// 
		/// </summary>
		public enum BlendMode
		{
			DoNotSetDest,
			UseImageBlender,
			ForceSourceOneDestOneMinusAlphaBlender
		}

		/// <summary>
		/// 
		/// </summary>
		public RendererBase ()
		{
			TextPath = new GsvText ();
			//StrockedText = new ConvStroke (TextPath);
			affineTransformStack.Push (Affine.NewIdentity ());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destImage">
		/// A <see cref="IImage"/>
		/// </param>
		/// <param name="rasterizer">
		/// A <see cref="ScanlineRasterizer"/>
		/// </param>
		public RendererBase (IImage destImage, ScanlineRasterizer rasterizer) : this()
		{
			Initialize (destImage, rasterizer);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destImage">
		/// A <see cref="IImage"/>
		/// </param>
		/// <param name="rasterizer">
		/// A <see cref="ScanlineRasterizer"/>
		/// </param>
		public void Initialize (IImage destImage, ScanlineRasterizer rasterizer)
		{
			m_DestImage = destImage;
			m_DestImageFloat = null;
			this.rasterizer = rasterizer;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destImage">
		/// A <see cref="IImageFloat"/>
		/// </param>
		/// <param name="rasterizer">
		/// A <see cref="ScanlineRasterizer"/>
		/// </param>
		public void Initialize (IImageFloat destImage, ScanlineRasterizer rasterizer)
		{
			m_DestImage = null;
			m_DestImageFloat = destImage;
			this.rasterizer = rasterizer;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public Affine PopTransform ()
		{
			if (affineTransformStack.Count == 1) {
				throw new System.Exception ("You cannot remove the last transform from the stack.");
			}
			
			return affineTransformStack.Pop ();
		}

		/// <summary>
		/// 
		/// </summary>
		public void PushTransform ()
		{
			if (affineTransformStack.Count > 1000) {
				throw new System.Exception ("You seem to be leaking transforms.  You should be poping some of them at some point.");
			}
			
			affineTransformStack.Push (affineTransformStack.Peek ());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public Affine GetTransform ()
		{
			return affineTransformStack.Peek ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">
		/// A <see cref="Affine"/>
		/// </param>
		public void SetTransform (Affine value)
		{
			affineTransformStack.Pop ();
			affineTransformStack.Push (value);
		}

		/// <summary>
		/// 
		/// </summary>
		public ScanlineRasterizer Rasterizer {
			get { return rasterizer; }
		}

		/// <summary>
		/// 
		/// </summary>
		public abstract IScanlineCache ScanlineCache { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IImage DestImage {
			get { return m_DestImage; }
		}

		/// <summary>
		/// 
		/// </summary>
		public IImageFloat DestImageFloat {
			get { return m_DestImageFloat; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vertexSource">
		/// A <see cref="IVertexSource"/>
		/// </param>
		/// <param name="pathIndexToRender">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="colorBytes">
		/// A <see cref="RgbaBytes"/>
		/// </param>
		public abstract void Render (IVertexSource vertexSource, int pathIndexToRender, RgbaBytes colorBytes);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="imageSource">
		/// A <see cref="IImage"/>
		/// </param>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		public void Render (IImage imageSource, double x, double y)
		{
			Render (imageSource, x, y, 0, 1, 1, new RgbaBytes (255, 255, 255), BlendMode.ForceSourceOneDestOneMinusAlphaBlender);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="imageSource">
		/// A <see cref="IImage"/>
		/// </param>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="color">
		/// A <see cref="RgbaBytes"/>
		/// </param>
		public void Render (IImage imageSource, double x, double y, RgbaBytes color)
		{
			Render (imageSource, x, y, 0, 1, 1, color, BlendMode.ForceSourceOneDestOneMinusAlphaBlender);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="imageSource">
		/// A <see cref="IImage"/>
		/// </param>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="color">
		/// A <see cref="RgbaBytes"/>
		/// </param>
		/// <param name="renderingMode">
		/// A <see cref="BlendMode"/>
		/// </param>
		public void Render (IImage imageSource, double x, double y, RgbaBytes color, BlendMode renderingMode)
		{
			Render (imageSource, x, y, 0, 1, 1, color, renderingMode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="imageSource">
		/// A <see cref="IImage"/>
		/// </param>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="angleDegrees">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="scaleX">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="ScaleY">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="color">
		/// A <see cref="RgbaBytes"/>
		/// </param>
		/// <param name="renderingMode">
		/// A <see cref="BlendMode"/>
		/// </param>
		public abstract void Render (IImage imageSource, double x, double y, double angleDegrees, double scaleX, double ScaleY, RgbaBytes color, BlendMode renderingMode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="imageSource">
		/// A <see cref="IImageFloat"/>
		/// </param>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="angleDegrees">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="scaleX">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="ScaleY">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="color">
		/// A <see cref="RGBA_Floats"/>
		/// </param>
		/// <param name="renderingMode">
		/// A <see cref="BlendMode"/>
		/// </param>
		public abstract void Render (IImageFloat imageSource, double x, double y, double angleDegrees, double scaleX, double ScaleY, RgbaFloats color, BlendMode renderingMode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vertexSource">
		/// A <see cref="IVertexSource"/>
		/// </param>
		/// <param name="colorArray">
		/// A <see cref="RgbaBytes[]"/>
		/// </param>
		/// <param name="pathIdArray">
		/// A <see cref="System.Int32[]"/>
		/// </param>
		/// <param name="numPaths">
		/// A <see cref="System.Int32"/>
		/// </param>
		public void Render (IVertexSource vertexSource, RgbaBytes[] colorArray, int[] pathIdArray, int numPaths)
		{
			for (int i = 0; i < numPaths; i++) {
				Render (vertexSource, pathIdArray[i], colorArray[i]);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vertexSource">
		/// A <see cref="IVertexSource"/>
		/// </param>
		/// <param name="color">
		/// A <see cref="RgbaBytes"/>
		/// </param>
		public void Render (IVertexSource vertexSource, RgbaBytes color)
		{
			Render (vertexSource, 0, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="color">
		/// A <see cref="IColorType"/>
		/// </param>
		public abstract void Clear (IColorType color);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Text">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		public void DrawString (string Text, double x, double y)
		{
			DrawString (Text, x, y, new RgbaBytes (0, 0, 0, 255));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Text">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="color">
		/// A <see cref="RgbaBytes"/>
		/// </param>
		public void DrawString (string Text, double x, double y, RgbaBytes color)
		{
			TextPath.SetFontSize (10);
			TextPath.start_point (x, y);
			TextPath.text (Text);
			Render (StrockedText, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Start">
		/// A <see cref="Vector2D"/>
		/// </param>
		/// <param name="End">
		/// A <see cref="Vector2D"/>
		/// </param>
		/// <param name="color">
		/// A <see cref="RgbaBytes"/>
		/// </param>
		public void Line (Vector2D Start, Vector2D End, RgbaBytes color)
		{
			Line (Start.x, Start.y, End.x, End.y, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x1">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y1">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="x2">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y2">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="color">
		/// A <see cref="RgbaBytes"/>
		/// </param>
		public void Line (double x1, double y1, double x2, double y2, RgbaBytes color)
		{
			// TODO
		}
			/*PathStorage _LinesToDraw = new PathStorage ();
			_LinesToDraw.remove_all ();
			_LinesToDraw.MoveTo (x1, y1);
			_LinesToDraw.LineTo (x2, y2);
			ConvStroke StrockedLineToDraw = new ConvStroke (_LinesToDraw);*/			
			//Render (StrockedLineToDraw, color);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect_d">
		/// A <see cref="rect_d"/>
		/// </param>
				public abstract void SetClippingRect (RectD rectD);
	}
}

