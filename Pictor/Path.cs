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

		public static bool IsVertex (FlagsAndCommand command)
		{
			return command >= FlagsAndCommand.CommandMoveTo && command < FlagsAndCommand.CommandEndPoly;
		}

		public static bool IsStop (FlagsAndCommand command)
		{
			return command == FlagsAndCommand.CommandStop;
		}

		public static bool IsMoveTo (FlagsAndCommand command)
		{
			return command == FlagsAndCommand.CommandMoveTo;
		}

		public static bool IsEndPoly (FlagsAndCommand command)
		{
			return (command & FlagsAndCommand.CommandsMask) == FlagsAndCommand.CommandEndPoly;
		}
	}
}

