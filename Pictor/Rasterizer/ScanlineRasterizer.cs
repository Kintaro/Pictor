using System;
using Pictor.VertexSource;
using Pictor.Gamma;
namespace Pictor.Rasterizer
{
	public sealed class ScanlineRasterizer : IRasterizer
	{
		public void AddPath (IVertexSource vs, int path_id)
		{
			throw new NotImplementedException ();
		}

		public void AddPath (IVertexSource vs)
		{
			throw new NotImplementedException ();
		}

		public void Gamma (IGammaFunction gammaFunction)
		{
			throw new NotImplementedException ();
		}

		public int MaxX {
			get {
				throw new NotImplementedException ();
			}
		}

		public int MaxY {
			get {
				throw new NotImplementedException ();
			}
		}

		public int MinX {
			get {
				throw new NotImplementedException ();
			}
		}

		public int MinY {
			get {
				throw new NotImplementedException ();
			}
		}

		public void Reset ()
		{
			throw new NotImplementedException ();
		}

		public bool RewindScanlines ()
		{
			throw new NotImplementedException ();
		}

		public bool SweepScanline (IScanlineCache sl)
		{
			throw new NotImplementedException ();
		}
	}
}

