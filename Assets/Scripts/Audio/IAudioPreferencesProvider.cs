using System.Collections.Generic;

namespace Audio
{
	public interface IAudioPreferencesProvider
	{
		IEnumerable<AudioPreferences> Preferences { get; }
	}
}