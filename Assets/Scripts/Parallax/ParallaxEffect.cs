using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private List<ParallaxLayer> _layers;
    [SerializeField] private Transform _character;

    private float _previousCharacterPosition;

    private void Start()
    {
        _previousCharacterPosition = _character.position.x;
    }

    private void FixedUpdate()
    {
        foreach (var layer in _layers)
        {
            Vector2 layerPosition = layer.Transform.position;
            layerPosition.x += layer.Speed * -0.1f;
            layer.Transform.position = layerPosition;
        }
    }

    private void LateUpdate()
    {
        float deltaMovement = _previousCharacterPosition - _character.position.x;
        foreach (var layer in _layers)
        {
            Vector2 layerPosition = layer.Transform.position;
            layerPosition.x += deltaMovement * layer.Speed;
            layer.Transform.position = layerPosition;
        }
        _previousCharacterPosition = _character.position.x;
    }

    [Serializable]
    private class ParallaxLayer
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public float Speed { get; private set;  }
    }
}
