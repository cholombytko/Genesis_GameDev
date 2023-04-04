using System.Collections;
using UnityEngine;
using Character;

public class InputReader : MonoBehaviour
{
    [SerializeField] private CharacterEntity _character;

    private float _horizontalDirection;

    private void Update()
    {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
            _character.Jump();

        _character.MoveHorizontally(_horizontalDirection);
    }
}
