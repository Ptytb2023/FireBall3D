using UnityEngine;
using UnityEngine.Audio;

namespace UI.Buttons.States
{
    public abstract class ConfigureVolumeButtonState : IconChangeButtonState
    {
        [Header("Volume Setting")]
        [SerializeField] private string _volumeExposidParametr;
        [SerializeField] private AudioMixer _mixer;


        protected abstract float VolumeLevel { get; }
        protected override void OnStateEnter()
        {
            _mixer.SetFloat(_volumeExposidParametr, VolumeLevel);
        }
    }
}
