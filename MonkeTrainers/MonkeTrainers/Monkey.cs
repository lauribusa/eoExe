using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeTrainers
{
	public enum TrickType
	{
		MUSIQUE,
		ACROBATIE
	}

	public struct Trick
	{
		public string TrickName;
		public TrickType TrickType;
		public ITrickable TrickPerformer;
		public Trick(string name, TrickType type, ITrickable trickPerformer)
		{
			this.TrickName = name;
			this.TrickType = type;
			this.TrickPerformer = trickPerformer;
		}
	}

	class Monkey : ITrickable
	{

		Trick[] knownTricks;
		private readonly string name;
		public Trick[] ReturnTrickList()
		{
			return knownTricks;
		}

		public Trick ReturnTrick(int i)
		{
			return knownTricks[i];
		}

		public string GetName()
		{
			return name;
		}
		public Monkey(string name)
		{
			this.name = name;
			knownTricks = new Trick[] { new Trick("Macarena", TrickType.MUSIQUE, this), 
				new Trick("Kickflip", TrickType.ACROBATIE, this), 
				new Trick("Double Flip-Flap carpé", TrickType.ACROBATIE, this), 
				new Trick("Dorime", TrickType.MUSIQUE, this), 
				new Trick("Commander sur Amazon", TrickType.ACROBATIE, this) };
		}
	}
}
