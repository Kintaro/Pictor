using System;
using Math = System.Math;
namespace Pictor
{
	/// <summary>
	/// 
	/// </summary>
	public class RgbaDoubles : IColorType
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
		public double _r;
		/// <summary>
		/// 
		/// </summary>
		public double _g;
		/// <summary>
		/// 
		/// </summary>
		public double _b;
		/// <summary>
		/// 
		/// </summary>
		public double _a;

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
		public RgbaDoubles (double r, double g, double b) : this(r, g, b, 1.0)
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
		public RgbaDoubles (double r, double g, double b, double a)
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
		/// A <see cref="RgbaDoubles"/>
		/// </param>
		public RgbaDoubles (RgbaDoubles color) : this(color, 1)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="color">
		/// A <see cref="RgbaDoubles"/>
		/// </param>
		/// <param name="a">
		/// A <see cref="System.Double"/>
		/// </param>
		public RgbaDoubles (RgbaDoubles color, double a) : this(color._r, color._g, color._b, color._a)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public int r {
			get { return (int)(this._r * BaseMask); }
			set { this._r = (double)value / (double)BaseMask; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int g {
			get { return (int)(this._g * BaseMask); }
			set { this._g = (double)value / (double)BaseMask; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int b {
			get { return (int)(this._b * BaseMask); }
			set { this._b = (double)value / (double)BaseMask; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int a {
			get { return (int)(this._a * BaseMask); }
			set { this._a = (double)value / (double)BaseMask; }
		}
		/// <summary>
		/// 
		/// </summary>
		public RgbaDoubles AsRgbaDoubles {
			get { return this; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		public RgbaFloats AsRgbaFloats {
			get { return new RgbaFloats ((float)_r, (float)_g, (float)_b, (float)_a); }
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
		public RgbaDoubles Transparent {
			get {
				this._a = 0.0;
				return this;
			}
		}

		/// <summary>
		/// 	Returns the color's opacity level
		/// </summary>
		public double Opacity {
			get { return this._a; }
		}


		/// <summary>
		/// 	Reset all values to zero
		/// </summary>
		public void Clear ()
		{
			this._r = this._g = this._b = this._a = 0.0;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="wl">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="RgbaDoubles"/>
		/// </returns>
		public static RgbaDoubles FromWavelength (double wl)
		{
			return FromWavelength (wl, 1.0);
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
		/// A <see cref="RgbaDoubles"/>
		/// </returns>
		public static RgbaDoubles FromWavelength (double wl, double gamma)
		{
			RgbaDoubles t = new RgbaDoubles (0.0, 0.0, 0.0);
			
			if (wl >= 380.0 && wl <= 440.0) {
				t._r = -1.0 * (wl - 440.0) / (440.0 - 380.0);
				t._b = 1.0;
			} else if (wl >= 440.0 && wl <= 490.0) {
				t._g = (wl - 440.0) / (490.0 - 440.0);
				t._b = 1.0;
			} else if (wl >= 490.0 && wl <= 510.0) {
				t._g = 1.0;
				t._b = -1.0 * (wl - 510.0) / (510.0 - 490.0);
			} else if (wl >= 510.0 && wl <= 580.0) {
				t._r = (wl - 510.0) / (580.0 - 510.0);
				t._g = 1.0;
			} else if (wl >= 580.0 && wl <= 645.0) {
				t._r = 1.0;
				t._g = -1.0 * (wl - 645.0) / (645.0 - 580.0);
			} else if (wl >= 645.0 && wl <= 780.0) {
				t._r = 1.0;
			}
			
			double s = 1.0;
			if (wl > 700.0)
				s = 0.3 + 0.7 * (780.0 - wl) / (780.0 - 700.0); 
			else if (wl < 420.0)
				s = 0.3 + 0.7 * (wl - 380.0) / (420.0 - 380.0);
			
			t._r = Math.Pow (t._r * s, gamma);
			t._g = Math.Pow (t._g * s, gamma);
			t._b = Math.Pow (t._b * s, gamma);
			
			return t;
		}
	}
}

