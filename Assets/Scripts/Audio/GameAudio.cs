using System.Collections.Generic;
using System.Linq;
using UnityEngine.Audio;

namespace Audio
{
	public class GameAudio : IAudioOperations, IAudioPreferencesProvider, IAudioStatusProvider
	{
		private const float EnabledVolume = 0.0f;
		private const float DisabledVolume = -80.0f;

		private readonly AudioMixer _audioMixer;

		private readonly Dictionary<AudioGroup, string> _parameters = new Dictionary<AudioGroup, string>
		{
			{AudioGroup.Sfx, "SfxVolume"},
			{AudioGroup.BackgroundMusic, "BackgroundMusicVolume"}
		};

		private readonly Dictionary<AudioGroup, float> _volumes;

		public GameAudio(AudioMixer audioMixer, IEnumerable<AudioPreferences> preferences)
		{
			_audioMixer = audioMixer;
			_volumes = preferences.ToDictionary(x => x.Group, x => x.Volume);
		}

		public void Initialize()
		{
			foreach (KeyValuePair<AudioGroup, float> preferences in _volumes)
			{
				string parameter = _parameters[preferences.Key];
				_audioMixer.SetFloat(parameter, preferences.Value);
			}
		}

		public void Enable(AudioGroup audioGroup) =>
			ConfigureVolume(audioGroup, EnabledVolume);

		public void Disable(AudioGroup audioGroup) =>
			ConfigureVolume(audioGroup, DisabledVolume);

		private void ConfigureVolume(AudioGroup audioGroup, float volume)
		{
			string parameter = _parameters[audioGroup];
			_volumes[audioGroup] = volume;
			_audioMixer.SetFloat(parameter, volume);
		}

		public IEnumerable<AudioPreferences> Preferences => _volumes.Select(x => new AudioPreferences(x.Key, x.Value));
		
		public AudioStatus StatusOf(AudioGroup group) => 
			_volumes[group] == EnabledVolume
				? AudioStatus.Enabled
				: AudioStatus.Disabled;
	}
}