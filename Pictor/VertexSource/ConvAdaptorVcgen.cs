using System;
namespace Pictor.VertexSource
{
	public class ConvAdaptorVcgen
	{
		private enum Status
		{
			Initial,
			Accumulate,
			Generate
		}

		private IVertexSource source;
		private IGenerator generator;
		private IMarkers markers;
		private Status status;
		private Path.FlagsAndCommand lastCommand;
		private double startX;
		private double startY;

		public ConvAdaptorVcgen (IVertexSource source, IGenerator generator)
		{
			this.markers = null;
			// TODO NullMarkers();
			this.source = source;
			this.generator = generator;
			this.status = Status.Initial;
		}

		public ConvAdaptorVcgen (IVertexSource source, IGenerator generator, IMarkers markers) : this(source, generator)
		{
			this.markers = markers;
		}

		protected IGenerator Generator { get { return this.generator; } }

		public void Attach (IVertexSource source)
		{
			this.source = source;
		}

		public void Rewind (int path_id)
		{
			source.Rewind (path_id);
			status = Status.Initial;
		}


		public Pictor.Path.FlagsAndCommand Vertex (out double x, out double y)
		{
			x = 0;
			y = 0;
			Path.FlagsAndCommand cmd = Path.FlagsAndCommand.CommandStop;
			bool done = false;
			while (!done) {
				switch (status) {
					case Status.Initial:
						markers.RemoveAll ();
						lastCommand = source.Vertex (out startX, out startY);
						status = Status.Accumulate;
						goto case Status.Accumulate;
					
					case Status.Accumulate:
						if (Path.IsStop (lastCommand))
							return Path.FlagsAndCommand.CommandStop;
						
						generator.RemoveAll ();
						generator.AddVertex (startX, startY, Path.FlagsAndCommand.CommandMoveTo);
						markers.AddVertex (startX, startY, Path.FlagsAndCommand.CommandMoveTo);
						
						while (true) {
							cmd = source.Vertex (out x, out y);
							
							if (Path.IsVertex (cmd)) {
								lastCommand = cmd;
								if (Path.IsMoveTo (cmd)) {
									startX = x;
									startY = y;
									break;
								}
								generator.AddVertex (x, y, cmd);
								markers.AddVertex (x, y, Path.FlagsAndCommand.CommandLineTo);
							} else {
								if (Path.IsStop (cmd)) {
									lastCommand = Path.FlagsAndCommand.CommandStop;
									break;
								}
								if (Path.IsEndPoly (cmd)) {
									generator.AddVertex (x, y, cmd);
									break;
								}
							}
							
							generator.Rewind (0);
							status = Status.Generate;
							goto case Status.Generate;
						}

						
						break;
					
					case Status.Generate:
						cmd = generator.Vertex (ref x, ref y);
						if (Path.IsStop (cmd)) {
							status = Status.Accumulate;
							break;
						}
						done = true;
						break;
				}
			}
			return cmd;
		}
	}
}

