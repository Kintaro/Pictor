using System;
namespace Pictor.Gamma
{
	public class GammaLinear : IGammaFunction
	{
		public GammaLinear () : this(0.0, 1.0)
		{
		}

		public GammaLinear (double start, double end)
		{
			this.Start = start;
			this.End = end;
		}

		public double Start { get; set; }
		public double End { get; set; }

		public void Set (double start, double end)
		{
			this.Start = start;
			this.End = end;
		}

		public double GetGamma (double x)
		{
			if (x < this.Start)
				return 0.0;
			if (x > this.End)
				return 1.0;

			double delta = this.End - this.Start;

			if (delta != 0.0)
				return (x - this.Start) / delta;
			return 0.0;
		}
	}
}

