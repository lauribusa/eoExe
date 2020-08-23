namespace MonkeTrainers
{
	public interface ITrickable
	{
		Trick ReturnTrick(int i);
		Trick[] ReturnTrickList();

		string GetName();
	}
}