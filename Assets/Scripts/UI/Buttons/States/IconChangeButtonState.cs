using StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons.States
{
    [RequireComponent(typeof(Image), (typeof(AudioSource)))]
    public abstract class IconChangeButtonState : MonoState
    {
        [SerializeField] private Sprite _iconChange;
        [SerializeField] private AudioClip _clickSound;

        private Image _image;
        private AudioSource _audioSource;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _audioSource = GetComponent<AudioSource>();

            _audioSource.mute = true;
        }

        public override void Enter()
        {
            _image.sprite = _iconChange;
            _audioSource.PlayOneShot(_clickSound);

            _audioSource.mute = false;
            OnStateEnter();
        }

        protected virtual void OnStateEnter() { }
    }

}
