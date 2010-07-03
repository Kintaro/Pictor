using System;
namespace Pictor.Transform
{
	/// <summary>
	/// 
	/// </summary>
	public struct Affine : ITransform
	{
		/// <summary>
		/// 
		/// </summary>
		public static double AffineEpsilon = 1e-14;
		/// <summary>
		/// 
		/// </summary>
		public double sx, shy, shx, sy, tx, ty;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="copyFrom">
		/// A <see cref="Affine"/>
		/// </param>
		public Affine (Affine copyFrom)
		{
			sx = copyFrom.sx;
			shy = copyFrom.shy;
			shx = copyFrom.shx;
			sy = copyFrom.sy;
			tx = copyFrom.tx;
			ty = copyFrom.ty;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="v0">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="v1">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="v2">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="v3">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="v4">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="v5">
		/// A <see cref="System.Double"/>
		/// </param>
		public Affine (double v0, double v1, double v2, double v3, double v4, double v5)
		{
			sx = v0;
			shy = v1;
			shx = v2;
			sy = v3;
			tx = v4;
			ty = v5;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="m">
		/// A <see cref="System.Double[]"/>
		/// </param>
		public Affine (double[] m)
		{
			sx = m[0];
			shy = m[1];
			shx = m[2];
			sy = m[3];
			tx = m[4];
			ty = m[5];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public static Affine NewIdentity ()
		{
			Affine newAffine = new Affine ();
			newAffine.sx = 1.0;
			newAffine.shy = 0.0;
			newAffine.shx = 0.0;
			newAffine.sy = 1.0;
			newAffine.tx = 0.0;
			newAffine.ty = 0.0;
			
			return newAffine;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AngleRadians">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public static Affine NewRotation (double AngleRadians)
		{
			return new Affine (Math.Cos (AngleRadians), Math.Sin (AngleRadians), -Math.Sin (AngleRadians), Math.Cos (AngleRadians), 0.0, 0.0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Scale">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public static Affine NewScaling (double Scale)
		{
			return new Affine (Scale, 0.0, 0.0, Scale, 0.0, 0.0);
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
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public static Affine NewScaling (double x, double y)
		{
			return new Affine (x, 0.0, 0.0, y, 0.0, 0.0);
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
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public static Affine NewTranslation (double x, double y)
		{
			return new Affine (1.0, 0.0, 0.0, 1.0, x, y);
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
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public static Affine NewSkewing (double x, double y)
		{
			return new Affine (1.0, Math.Tan (y), Math.Tan (x), 1.0, 0.0, 0.0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Identity ()
		{
			sx = sy = 1.0;
			shy = shx = tx = ty = 0.0;
		}

		// Direct transformations operations
		public void Translate (double x, double y)
		{
			tx += x;
			ty += y;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AngleRadians">
		/// A <see cref="System.Double"/>
		/// </param>
		public void Rotate (double AngleRadians)
		{
			double ca = Math.Cos (AngleRadians);
			double sa = Math.Sin (AngleRadians);
			double t0 = sx * ca - shy * sa;
			double t2 = shx * ca - sy * sa;
			double t4 = tx * ca - ty * sa;
			shy = sx * sa + shy * ca;
			sy = shx * sa + sy * ca;
			ty = tx * sa + ty * ca;
			sx = t0;
			shx = t2;
			tx = t4;
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
		public void Scale (double x, double y)
		{
			double mm0 = x;
			// Possible hint for the optimizer
			double mm3 = y;
			sx *= mm0;
			shx *= mm0;
			tx *= mm0;
			shy *= mm3;
			sy *= mm3;
			ty *= mm3;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scaleAmount">
		/// A <see cref="System.Double"/>
		/// </param>
		public void Scale (double scaleAmount)
		{
			sx *= scaleAmount;
			shx *= scaleAmount;
			tx *= scaleAmount;
			shy *= scaleAmount;
			sy *= scaleAmount;
			ty *= scaleAmount;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="m">
		/// A <see cref="Affine"/>
		/// </param>
		void Multiply (Affine m)
		{
			double t0 = sx * m.sx + shy * m.shx;
			double t2 = shx * m.sx + sy * m.shx;
			double t4 = tx * m.sx + ty * m.shx + m.tx;
			shy = sx * m.shy + shy * m.sy;
			sy = shx * m.shy + sy * m.sy;
			ty = tx * m.shy + ty * m.sy + m.ty;
			sx = t0;
			shx = t2;
			tx = t4;
		}

		/// <summary>
		/// 
		/// </summary>
		public void Invert ()
		{
			double d = DeterminantReciprocal;
			
			double t0 = sy * d;
			sy = sx * d;
			shy = -shy * d;
			shx = -shx * d;
			
			double t4 = -tx * t0 - ty * shx;
			ty = -tx * shy - ty * sy;
			
			sx = t0;
			tx = t4;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="a">
		/// A <see cref="Affine"/>
		/// </param>
		/// <param name="b">
		/// A <see cref="Affine"/>
		/// </param>
		/// <returns>
		/// A <see cref="Affine"/>
		/// </returns>
		public static Affine operator * (Affine a, Affine b)
		{
			Affine temp = new Affine (a);
			temp.Multiply (b);
			return temp;
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
			double tmp = x;
			x = tmp * sx + y * shx + tx;
			y = tmp * shy + y * sy + ty;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pointToTransform">
		/// A <see cref="Vector2D"/>
		/// </param>
		public void Transform (ref Vector2D pointToTransform)
		{
			Transform (ref pointToTransform.x, ref pointToTransform.y);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rectToTransform">
		/// A <see cref="rect_d"/>
		/// </param>
		public void Transform (ref RectD rectToTransform)
		{
			Transform (ref rectToTransform.x1, ref rectToTransform.y1);
			Transform (ref rectToTransform.x2, ref rectToTransform.y2);
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
		public void InverseTransform (ref double x, ref double y)
		{
			double d = DeterminantReciprocal;
			double a = (x - tx) * d;
			double b = (y - ty) * d;
			x = a * sy - b * shx;
			y = b * sx - a * shy;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pointToTransform">
		/// A <see cref="Vector2D"/>
		/// </param>
		public void InverseTransform (ref Vector2D pointToTransform)
		{
			InverseTransform (ref pointToTransform.x, ref pointToTransform.y);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="System.Double"/>
		/// </returns>
		double DeterminantReciprocal {
			get { return 1.0 / (sx * sy - shy * shx); }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="System.Double"/>
		/// </returns>
		public double GetScale ()
		{
			double x = 0.707106781 * sx + 0.707106781 * shx;
			double y = 0.707106781 * shy + 0.707106781 * sy;
			return Math.Sqrt (x * x + y * y);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="epsilon">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public bool IsValid (double epsilon)
		{
			return Math.Abs (sx) > epsilon && Math.Abs (sy) > epsilon;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public bool IsIdentity ()
		{
			return IsIdentity (AffineEpsilon);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="epsilon">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public bool IsIdentity (double epsilon)
		{
			return PictorBasics.IsEqualEpsilon (sx, 1.0, epsilon) && PictorBasics.IsEqualEpsilon (shy, 0.0, epsilon) && PictorBasics.IsEqualEpsilon (shx, 0.0, epsilon) && PictorBasics.IsEqualEpsilon (sy, 1.0, epsilon) && PictorBasics.IsEqualEpsilon (tx, 0.0, epsilon) && PictorBasics.IsEqualEpsilon (ty, 0.0, epsilon);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="m">
		/// A <see cref="Affine"/>
		/// </param>
		/// <param name="epsilon">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public bool IsEqual (Affine m, double epsilon)
		{
			return PictorBasics.IsEqualEpsilon (sx, m.sx, epsilon) && PictorBasics.IsEqualEpsilon (shy, m.shy, epsilon) && PictorBasics.IsEqualEpsilon (shx, m.shx, epsilon) && PictorBasics.IsEqualEpsilon (sy, m.sy, epsilon) && PictorBasics.IsEqualEpsilon (tx, m.tx, epsilon) && PictorBasics.IsEqualEpsilon (ty, m.ty, epsilon);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// A <see cref="System.Double"/>
		/// </returns>
		public double Rotation ()
		{
			double x1 = 0.0;
			double y1 = 0.0;
			double x2 = 1.0;
			double y2 = 0.0;
			Transform (ref x1, ref y1);
			Transform (ref x2, ref y2);
			return Math.Atan2 (y2 - y1, x2 - x1);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dx">
		/// A <see cref="System.Double"/>
		/// </param>
		/// <param name="dy">
		/// A <see cref="System.Double"/>
		/// </param>
		public void Translation (out double dx, out double dy)
		{
			dx = tx;
			dy = ty;
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
		public void Scaling (out double x, out double y)
		{
			double x1 = 0.0;
			double y1 = 0.0;
			double x2 = 1.0;
			double y2 = 1.0;
			Affine t = new Affine (this);
			t *= NewRotation (-Rotation ());
			t.Transform (ref x1, ref y1);
			t.Transform (ref x2, ref y2);
			x = x2 - x1;
			y = y2 - y1;
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
		public void scaling_abs (out double x, out double y)
		{
			x = Math.Sqrt (sx * sx + shx * shx);
			y = Math.Sqrt (shy * shy + sy * sy);
		}
	}
}

