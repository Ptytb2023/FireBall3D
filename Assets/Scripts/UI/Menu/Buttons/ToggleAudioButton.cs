﻿using System;
using System.Collections.Generic;
using System.Linq;
using Audio;
using Extensions;
using IoC;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Image))]
    public class ToggleAudioButton : MonoBehaviour
    {
        [Serializable]
        private struct AudioStatusIcon
        {
            public AudioStatus Status;
            public Sprite Icon;
        }

        [SerializeField] private AudioGroup _group;
        [SerializeField] private AudioStatusIcon[] _icons;

        private Dictionary<AudioStatus, Sprite> _statuses;
        private Dictionary<AudioStatus, Action> _operations;

        private Image _image;

        private IAudioOperations _audioOperations => Container.InstanceOf<IAudioOperations>();
        private IAudioStatusProvider _statusProvider => Container.InstanceOf<IAudioStatusProvider>();



        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            _statuses = _icons.ToDictionary(x => x.Status, x => x.Icon);
            _image.sprite = _statuses[_statusProvider.StatusOf(_group)];

            _operations = new Dictionary<AudioStatus, Action>
            {
                {AudioStatus.Enabled, () => _audioOperations.Enable(_group)},
                {AudioStatus.Disabled, () => _audioOperations.Disable(_group)}
            };
        }

        public void OnButtonClicked()
        {
            AudioStatus audioStatus = _statusProvider.StatusOf(_group).Next();
            _image.sprite = _statuses[audioStatus];
            _operations[audioStatus].Invoke();
        }
    }
}