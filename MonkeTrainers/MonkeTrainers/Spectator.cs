using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeTrainers
{
	enum ReactionType
	{
		SIFFLE,
		APPLAUDIT
	}
	class Spectator
	{
		public ReactionType ReactToTrick(TrickType type)
		{
			if (type == TrickType.ACROBATIE)
			{
				return ReactionType.APPLAUDIT;
			}
			else
			{
				return ReactionType.SIFFLE;
			}
		}
	}
}
