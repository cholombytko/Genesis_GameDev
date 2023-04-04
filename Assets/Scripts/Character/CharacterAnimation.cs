using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _walkAnimationKey;
        [SerializeField] private string _jumpAnimationKey;

        private float _horizontalDirection;

        private void Update()
        {
            _horizontalDirection = Input.GetAxisRaw("Horizontal");

            if (_horizontalDirection != 0)
            {
                _animator.SetBool(_walkAnimationKey, true);
            }
            else if (_horizontalDirection == 0)
            {
                _animator.SetBool(_walkAnimationKey, false);
            }

            _animator.SetBool(_jumpAnimationKey, CharacterEntity.IsJumping);
        }
    }
}

