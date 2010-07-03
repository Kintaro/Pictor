using System;
namespace Pictor
{
	public static class Path
	{
		[Flags]
		public enum FlagsAndCommand
		{
			CommandStop = 0,
			CommandMoveTo = 1,
			CommandLineTo = 2,
			CommandCurve3 = 3,
			CommandCurve4 = 4,
			CommandEndPoly = 0x0F,
			CommandsMask = 0x0F,

			FlagNone = 0,
			FlagCCW = 0x10,
			FlagCW = 0x20,
			FlagClose = 0x40,
			FlagsMask = 0xF0
		}
	}
}

