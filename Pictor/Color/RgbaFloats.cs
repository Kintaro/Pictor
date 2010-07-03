using System;
using Math = System.Math;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public class RgbaFloats : IColorType
	{
		/// <summary>
		/// 
		/// </summary>
		const int BaseShift = 8;
		/// <summary>
		/// 
		/// </summary>
		const int BaseScale = (int)(1 << BaseShift);
		/// <summary>
		/// 
		/// </summary>
		const int BaseMask = BaseScale - 1;

		/// <summary>
		/// 
		/// </summary>
		private float _r;
		/// <summary>
		/// 
		/// </summary>
		private float _g;
		/// <summary>
		/// 
		/// </summary>
		private float _b;
		/// <summary>
		/// 
		/// </summary>
		private float _a;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="r">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="g">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="b">
		/// A <see cref="System.Double"/>
		/// </param>
		public RgbaFloats (float r, float g, float b) : this(r, g, b, 1.0f)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="r">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="g">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="b">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="a">
		/// A <see cref="System.Double"/>
		/// </param>
		public RgbaFloats (float r, float g, float b, float a)
		{
			this._r = r;
			this._g = g;
			this._b = b;
			this._a = a;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="color">
		/// A <see cref="RgbaFloats"/>
		/// </param>
		public RgbaFloats (RgbaFloats color) : this(color, 1)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="color">
		/// A <see cref="RgbaFloats"/>
		/// </param>
		/// <param name="a">
		/// A <see cref="System.Double"/>
		/// </param>
		public RgbaFloats (RgbaFloats color, float a) : this(color._r, color._g, color._b, color._a)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public int r {
			get { return (int)(this._r * BaseMask); }
			set { this._r = (float)value / (float)BaseMask; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int g {
			get { return (int)(this._g * BaseMask); }
			set { this._g = (float)value / (float)BaseMask; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int b {
			get { return (int)(this._b * BaseMask); }
			set { this._b = (float)value / (float)BaseMask; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int a {
			get { return (int)(this._a * BaseMask); }
			set { this._a = (float)value / (float)BaseMask; }
		}
		/// <summary>
		/// 
		/// </summary>
		public RgbaFloats AsRgbaFloats {
			get { return this; }
		}

		// <summary>
		/// 
		/// </summary>
		public RgbaDoubles AsRgbaDoubles {
			get { return new RgbaDoubles ((double)_r, (double)_g, (double)_b, (double)_a); }
		}

		/// <summary>
		/// 
		/// </summary>
		public RgbaBytes AsRgbaBytes {
			get { return new RgbaBytes (r, g, b, a); }
		}

		/// <summary>
		/// 	Makes this color transparent and returns it
		/// </summary>
		public RgbaFloats Transparent {
			get {
				this._a = 0.0f;
				return this;
			}
		}

		/// <summary>
		/// 	Returns the color's opacity level
		/// </summary>
		public float Opacity {
			get { return this._a; }
		}


		/// <summary>
		/// 	Reset all values to zero
		/// </summary>
		public void Clear ()
		{
			this._r = this._g = this._b = this._a = 0.0f;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wl">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="RgbaFloats"/>
		/// </returns>
		public static RgbaFloats FromWavelength (float wl)
		{
			return FromWavelength (wl, 1.0f);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wl">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="gamma">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="RgbaFloats"/>
		/// </returns>
		public static RgbaFloats FromWavelength (float wl, float gamma)
		{
			RgbaFloats t = new RgbaFloats (0.0f, 0.0f, 0.0f);
			
			if (wl >= 380.0f && wl <= 440.0f) {
				t._r = -1.0f * (wl - 440.0f) / (440.0f - 380.0f);
				t._b = 1.0f;
			} else if (wl >= 440.0f && wl <= 490.0f) {
				t._g = (wl - 440.0f) / (490.0f - 440.0f);
				t._b = 1.0f;
			} else if (wl >= 490.0f && wl <= 510.0f) {
				t._g = 1.0f;
				t._b = -1.0f * (wl - 510.0f) / (510.0f - 490.0f);
			} else if (wl >= 510.0 && wl <= 580.0) {
				t._r = (wl - 510.0f) / (580.0f - 510.0f);
				t._g = 1.0f;
			} else if (wl >= 580.0f && wl <= 645.0f) {
				t._r = 1.0f;
				t._g = -1.0f * (wl - 645.0f) / (645.0f - 580.0f);
			} else if (wl >= 645.0f && wl <= 780.0f) {
				t._r = 1.0f;
			}
			
			float s = 1.0f;
			if (wl > 700.0f)
				s = 0.3f + 0.7f * (780.0f - wl) / (780.0f - 700.0f); else if (wl < 420.0)
				s = 0.3f + 0.7f * (wl - 380.0f) / (420.0f - 380.0f);
			
			t._r = (float)Math.Pow (t._r * s, gamma);
			t._g = (float)Math.Pow (t._g * s, gamma);
			t._b = (float)Math.Pow (t._b * s, gamma);
			
			return t;
		}
	}
}

