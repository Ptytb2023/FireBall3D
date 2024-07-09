namespace Audio
{
	public interface IAudioStatusProvider
	{
		AudioStatus StatusOf(AudioGroup group);
	}
}