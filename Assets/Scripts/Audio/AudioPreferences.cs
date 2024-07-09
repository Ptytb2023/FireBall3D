namespace Audio
{
	public struct AudioPreferences
	{
		public AudioGroup Group { get; set; }
		public float Volume { get; set; }

		public AudioPreferences(AudioGroup group, float volume)
		{
			Group = group;
			Volume = volume;
		}
	}
}