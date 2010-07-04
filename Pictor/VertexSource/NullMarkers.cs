using System;
namespace Pictor.VertexSource
{
	public struct NullMarkers : IMarkers
	{
		public void RemoveAll ()
		{
		}

		public void AddVertex (double x, double y, Path.FlagsAndCommand unknown)
		{
		}

		public void PrepareSource ()
		{
		}

		public void Rewind (int unknown)
		{
		}

		public Path.FlagsAndCommand Vertex (ref double x, ref double y)
		{
			return Path.FlagsAndCommand.CommandStop;
		}
	}
}

