namespace Pictor.Transform
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class Bilinear : ITransform
	{
		/// <summary>
		/// 
		/// </summary>
		double[,] m_mtx = new double[4, 2];
		/// <summary>
		/// 
		/// </summary>
		bool m_valid;

		/// <summary>
		/// 
		/// </summary>
		public Bilinear ()
		{
			m_valid = (false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="src">
		/// A <see cref="System.Double[]"/>
		/// </param>
		/// <param name="dst">
		/// A <see cref="System.Double[]"/>
		/// </param>
		public Bilinear (double[] src, double[] dst)
		{
			QuadToQuad (src, dst);
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
		/// <param name="quad">
		/// A <see cref="System.Double[]"/>
		/// </param>
		public Bilinear (double x1, double y1, double x2, double y2, double[] quad)
		{
			RectToQuad (x1, y1, x2, y2, quad);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="quad">
		/// A <see cref="System.Double[]"/>
		/// </param>
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
		public Bilinear (double[] quad, double x1, double y1, double x2, double y2)
		{
			QuadToRect (quad, x1, y1, x2, y2);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="src">
		/// A <see cref="System.Double[]"/>
		/// </param>
		/// <param name="dst">
		/// A <see cref="System.Double[]"/>
		/// </param>
		public void QuadToQuad (double[] src, double[] dst)
		{
			double[,] left = new double[4, 4];
			double[,] right = new double[4, 2];
			
			uint i;
			for (i = 0; i < 4; i++) {
				uint ix = i * 2;
				uint iy = ix + 1;
				left[i, 0] = 1.0;
				left[i, 1] = src[ix] * src[iy];
				left[i, 2] = src[ix];
				left[i, 3] = src[iy];
				
				right[i, 0] = dst[ix];
				right[i, 1] = dst[iy];
			}
			m_valid = SimulEquation.Solve (left, right, m_mtx);
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
		/// <param name="quad">
		/// A <see cref="System.Double[]"/>
		/// </param>
		public void RectToQuad (double x1, double y1, double x2, double y2, double[] quad)
		{
			double[] src = new double[8];
			src[0] = src[6] = x1;
			src[2] = src[4] = x2;
			src[1] = src[3] = y1;
			src[5] = src[7] = y2;
			QuadToQuad (src, quad);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="quad">
		/// A <see cref="System.Double[]"/>
		/// </param>
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
		public void QuadToRect (double[] quad, double x1, double y1, double x2, double y2)
		{
			double[] dst = new double[8];
			dst[0] = dst[6] = x1;
			dst[2] = dst[4] = x2;
			dst[1] = dst[3] = y1;
			dst[5] = dst[7] = y2;
			QuadToQuad (quad, dst);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public bool IsValid {
			get { return m_valid; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		public void Transform (ref double x, ref double y)
		{
			double tx = x;
			double ty = y;
			double xy = tx * ty;
			x = m_mtx[0, 0] + m_mtx[1, 0] * xy + m_mtx[2, 0] * tx + m_mtx[3, 0] * ty;
			y = m_mtx[0, 1] + m_mtx[1, 1] * xy + m_mtx[2, 1] * tx + m_mtx[3, 1] * ty;
		}


		/// <summary>
		/// 
		/// </summary>
		public sealed class Iterator
		{
			/// <summary>
			/// 
			/// </summary>
			double inc_x;
			/// <summary>
			/// 
			/// </summary>
			double inc_y;

			/// <summary>
			/// 
			/// </summary>
			public double x;
			/// <summary>
			/// 
			/// </summary>
			public double y;

			/// <summary>
			/// 
			/// </summary>
			public Iterator ()
			{
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="tx">
			/// A <see cref="System.Double"/>
			/// </param>
			/// <param name="ty">
			/// A <see cref="System.Double"/>
			/// </param>
			/// <param name="step">
			/// A <see cref="System.Double"/>
			/// </param>
			/// <param name="m">
			/// A <see cref="System.Double[,]"/>
			/// </param>
			public Iterator (double tx, double ty, double step, double[,] m)
			{
				inc_x = (m[1, 0] * step * ty + m[2, 0] * step);
				inc_y = (m[1, 1] * step * ty + m[2, 1] * step);
				x = (m[0, 0] + m[1, 0] * tx * ty + m[2, 0] * tx + m[3, 0] * ty);
				y = (m[0, 1] + m[1, 1] * tx * ty + m[2, 1] * tx + m[3, 1] * ty);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="a">
			/// A <see cref="iterator_x"/>
			/// </param>
			/// <returns>
			/// A <see cref="iterator_x"/>
			/// </returns>
			public static Iterator operator ++ (Iterator a)
			{
				a.x += a.inc_x;
				a.y += a.inc_y;
				
				return a;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="y">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="step">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="Iterator"/>
		/// </returns>
		public Iterator Begin (double x, double y, double step)
		{
			return new Iterator (x, y, step, m_mtx);
		}
	}
}

