using System;
namespace Pictor.Gamma
{
	public class GammaPower : IGammaFunction
	{
		public GammaPower () : this(1.0)
		{
		}

		public GammaPower (double gamma)
		{
			this.Gamma = gamma;
		}

		public double Gamma { get; set; }

		public double GetGamma (double x)
		{
			return Math.Pow (x, this.Gamma);
		}
	}
}

