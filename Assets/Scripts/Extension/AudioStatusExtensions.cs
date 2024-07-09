using Audio;

namespace Extensions
{
	public static class AudioStatusExtensions
	{
		public static AudioStatus Next(this AudioStatus status) => 
			status == AudioStatus.Enabled ? AudioStatus.Disabled : AudioStatus.Enabled;
	}
}