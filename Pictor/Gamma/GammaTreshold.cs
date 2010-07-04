using System;
namespace Pictor.Gamma
{
	public class GammaTreshold : IGammaFunction
	{
		public GammaTreshold () : this(0.5)
		{
		}

		public GammaTreshold (double treshold)
		{
			this.Treshold = treshold;
		}

		public double Treshold { get; set; }

		public double GetGamma (double x)
		{
			return (x < this.Treshold) ? 0.0 : 1.0;
		}
	}
}

