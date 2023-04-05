using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class GameLevelInitializer : MonoBehaviour
{
    [SerializeField] private CharacterEntity _characterEntity;
    [SerializeField] private GameUIInputView _gameUiInputView;

    private ExternalDevicesInputReader _externalDevicesInput;
    private CharacterBrain _characterBrain;

    private bool _onPause;
    private void Awake()
    {
        _externalDevicesInput = new ExternalDevicesInputReader();
        _characterBrain = new CharacterBrain(_characterEntity, new List<IEntityInputSource>
        {
            _gameUiInputView,
            _externalDevicesInput
        });
    }

    private void Update()
    {
        if (_onPause)
            return;
        _externalDevicesInput.OnUpdate();
    }

    private void FixedUpdate()
    {
        if (_onPause)
            return;
        _characterBrain.OnFixedUpdate();
    }
}
