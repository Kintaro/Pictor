using System;
namespace Pictor
{
	public struct RectD
	{
		public double x1, y1, x2, y2;
		public double Left {
			get { return x1; }
			set { x1 = value; }
		}

		public double Bottom {
			get { return y1; }
			set { y1 = value; }
		}

		public double Right {
			get { return x2; }
			set { x2 = value; }
		}

		public double Top {
			get { return y2; }
			set { y2 = value; }
		}
	}
}

