using System;
namespace Pictor.VertexSource
{
	public sealed class ConvStroke : ConvAdaptorVcgen, IVertexSource
	{
		public ConvStroke (IVertexSource source) : base (source, new VcGenStroke())
		{}
	}
}

