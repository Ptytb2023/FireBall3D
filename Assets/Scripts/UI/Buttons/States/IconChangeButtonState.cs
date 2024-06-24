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

        private void Start()
        {
            _image = GetComponent<Image>();
            _audioSource = GetComponent<AudioSource>();

            _audioSource.mute = true;
        }

        public override void Enter()
        {
            _audioSource.mute = false;

            _image.sprite = _iconChange;
            _audioSource.PlayOneShot(_clickSound);

            OnStateEnter();

        }

        protected abstract void OnStateEnter();
    }

}
