using System;
namespace Pictor
{
	public struct RgbaBytes : IColorType
	{
		public const int CoverShift = 8;
		public const int CoverSize = 1 << CoverShift;
		public const int CoverMask = CoverSize - 1;
		public const int BaseShift = 8;
		public const int BaseScale = (int)(1 << BaseShift);
		public const int BaseMask = BaseScale - 1;

		public byte _b;
		public byte _g;
		public byte _r;
		public byte _a;

		public int r {
			get { return (int)_r; }
			set { _r = (byte)value; }
		}
		public int g {
			get { return (int)_g; }
			set { _g = (byte)value; }
		}
		public int b {
			get { return (int)_b; }
			set { _b = (byte)value; }
		}
		public int a {
			get { return (int)_a; }
			set { _a = (byte)value; }
		}

		public RgbaBytes (int r_, int g_, int b_) : this(r_, g_, b_, BaseMask)
		{
		}

		public RgbaBytes (int r_, int g_, int b_, int a_)
		{
			_r = (byte)r_;
			_g = (byte)g_;
			_b = (byte)b_;
			_a = (byte)a_;
		}

		public RgbaBytes (double r_, double g_, double b_, double a_)
		{
			_r = ((byte)PictorBasics.Uround (r_ * (double)BaseMask));
			_g = ((byte)PictorBasics.Uround (g_ * (double)BaseMask));
			_b = ((byte)PictorBasics.Uround (b_ * (double)BaseMask));
			_a = ((byte)PictorBasics.Uround (a_ * (double)BaseMask));
		}

		public RgbaBytes (double r_, double g_, double b_)
		{
			_r = ((byte)PictorBasics.Uround (r_ * (double)BaseMask));
			_g = ((byte)PictorBasics.Uround (g_ * (double)BaseMask));
			_b = ((byte)PictorBasics.Uround (b_ * (double)BaseMask));
			_a = (byte)BaseMask;
		}

		RgbaBytes (RgbaDoubles c, double a_)
		{
			_r = ((byte)PictorBasics.Uround (c._r * (double)BaseMask));
			_g = ((byte)PictorBasics.Uround (c._g * (double)BaseMask));
			_b = ((byte)PictorBasics.Uround (c._b * (double)BaseMask));
			_a = ((byte)PictorBasics.Uround (a_ * (double)BaseMask));
		}

		RgbaBytes (RgbaBytes c, int a_)
		{
			_r = (byte)c._r;
			_g = (byte)c._g;
			_b = (byte)c._b;
			_a = (byte)a_;
		}

		public RgbaBytes (RgbaDoubles c)
		{
			_r = ((byte)PictorBasics.Uround (c._r * (double)BaseMask));
			_g = ((byte)PictorBasics.Uround (c._g * (double)BaseMask));
			_b = ((byte)PictorBasics.Uround (c._b * (double)BaseMask));
			_a = ((byte)PictorBasics.Uround (c._a * (double)BaseMask));
		}

		public RgbaDoubles AsRgbaDoubles {
			get { return new RgbaDoubles ((double)_r / (double)BaseMask, (double)_g / (double)BaseMask, (double)_b / (double)BaseMask, (double)_a / (double)BaseMask); }
		}

		public RgbaFloats AsRgbaFloats {
			get { return new RgbaFloats ((float)_r / (float)BaseMask, (float)_g / (float)BaseMask, (float)_b / (float)BaseMask, (float)_a / (float)BaseMask); }
		}

		public RgbaBytes AsRgbaBytes {
			get { return this; }
		}

		void Clear ()
		{
			_r = _g = _b = _a = 0;
		}

		public RgbaBytes Gradient (RgbaBytes c, double k)
		{
			RgbaBytes ret = new RgbaBytes ();
			int ik = PictorBasics.Uround (k * BaseScale);
			ret.r = (byte)((int)(r) + ((((int)(c.r) - r) * ik) >> BaseShift));
			ret.g = (byte)((int)(g) + ((((int)(c.g) - g) * ik) >> BaseShift));
			ret.b = (byte)((int)(b) + ((((int)(c.b) - b) * ik) >> BaseShift));
			ret.a = (byte)((int)(a) + ((((int)(c.a) - a) * ik) >> BaseShift));
			return ret;
		}

		public void @add (RgbaBytes c, int cover)
		{
			int cr, cg, cb, ca;
			if (cover == CoverMask) {
				if (c.a == BaseMask) {
					this = c;
				} else {
					cr = r + c.r;
					r = (cr > (int)(BaseMask)) ? (int)(BaseMask) : cr;
					cg = g + c.g;
					g = (cg > (int)(BaseMask)) ? (int)(BaseMask) : cg;
					cb = b + c.b;
					b = (cb > (int)(BaseMask)) ? (int)(BaseMask) : cb;
					ca = a + c.a;
					a = (ca > (int)(BaseMask)) ? (int)(BaseMask) : ca;
				}
			} else {
				cr = r + ((c.r * cover + CoverMask / 2) >> CoverShift);
				cg = g + ((c.g * cover + CoverMask / 2) >> CoverShift);
				cb = b + ((c.b * cover + CoverMask / 2) >> CoverShift);
				ca = a + ((c.a * cover + CoverMask / 2) >> CoverShift);
				r = (cr > (int)(BaseMask)) ? (int)(BaseMask) : cr;
				g = (cg > (int)(BaseMask)) ? (int)(BaseMask) : cg;
				b = (cb > (int)(BaseMask)) ? (int)(BaseMask) : cb;
				a = (ca > (int)(BaseMask)) ? (int)(BaseMask) : ca;
			}
		}
		/*
        public void ApplyGammaDir(GammaLookUpTable gamma)
        {
        	r = gamma.dir((byte)r);
            g = gamma.dir((byte)g);
            b = gamma.dir((byte)b);
        }
        */
		public static IColorType no_color ()
		{
			return new RgbaBytes (0, 0, 0, 0);
		}

		//-------------------------------------------------------------rgb8_packed
		public static RgbaBytes Rgb8Packed (int v)
		{
			return new RgbaBytes ((v >> 16) & 0xFF, (v >> 8) & 0xFF, v & 0xFF);
		}
	}
}

