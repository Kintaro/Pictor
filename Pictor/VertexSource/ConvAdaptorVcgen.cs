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

		private IVertexSource m_source;
		private IGenerator m_generator;
		private IMarkers m_markers;
		private Status m_status;
		private Path.FlagsAndCommand m_last_cmd;
		private double m_start_x;
		private double m_start_y;

		public void Rewind (int path_id)
		{
			m_source.Rewind (path_id);
			m_status = Status.Initial;
		}


		public Pictor.Path.FlagsAndCommand Vertex (out double x, out double y)
		{
			x = 0;
			y = 0;
			Path.FlagsAndCommand cmd = Path.FlagsAndCommand.CommandStop;
			bool done = false;
			while (!done) {
				switch (m_status) {
					case Status.Initial:
						m_markers.RemoveAll ();
						m_last_cmd = m_source.Vertex (out m_start_x, out m_start_y);
						m_status = Status.Accumulate;
						goto case Status.Accumulate;
					
					case Status.Accumulate:
						// TODO
						//if (Path.IsStop(m_last_cmd)) return Path.FlagsAndCommand.CommandStop;
						
						m_generator.RemoveAll ();
						m_generator.AddVertex (m_start_x, m_start_y, Path.FlagsAndCommand.CommandMoveTo);
						m_markers.AddVertex (m_start_x, m_start_y, Path.FlagsAndCommand.CommandMoveTo);
						
						for (;;) {
							cmd = m_source.Vertex (out x, out y);
							//DebugFile.Print("x=" + x.ToString() + " y=" + y.ToString() + "\n");
						}
							/*if (Path.is_vertex(cmd))
                        {
                            m_last_cmd = cmd;
                            if(Path.is_move_to(cmd))
                            {
                                m_start_x = x;
                                m_start_y = y;
                                break;
                            }
                            m_generator.AddVertex(x, y, cmd);
                            m_markers.add_vertex(x, y, Path.FlagsAndCommand.CommandLineTo);
                        }
                        else
                        {
                            if(Path.is_stop(cmd))
                            {
                                m_last_cmd = Path.FlagsAndCommand.CommandStop;
                                break;
                            }
                            if(Path.is_end_poly(cmd))
                            {
                                m_generator.AddVertex(x, y, cmd);
                                break;
                            }
                        }*/							
						
						m_generator.Rewind (0);
						m_status = Status.Generate;
						goto case Status.Generate;
					
					case Status.Generate:
						cmd = m_generator.Vertex (ref x, ref y);
						//DebugFile.Print("x=" + x.ToString() + " y=" + y.ToString() + "\n");
												/*if (Path.is_stop(cmd))
                    {
                        m_status = Status.Accumulate;
                        break;
                    }*/
done = true;
						break;
				}
			}
			return cmd;
		}
	}
}

