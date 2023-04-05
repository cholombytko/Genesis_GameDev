using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Character
{
    public class CharacterBrain
    {
        private readonly CharacterEntity _characterEntity;
        private readonly List<IEntityInputSource> _inputSources;

        public CharacterBrain(CharacterEntity characterEntity, List<IEntityInputSource> inputSources)
        {
            _characterEntity = characterEntity;
            _inputSources = inputSources;
        }

        public void OnFixedUpdate()
        {
            _characterEntity.MoveHorizontally(GetHorizontalDirection());
            if(IsJump)
                _characterEntity.Jump();

            foreach(var inputSource in _inputSources)
                inputSource.ResetOneTimeAction();
        }

        private float GetHorizontalDirection()
        {
            foreach (var inputSource in _inputSources)
            {
                if(inputSource.HorizontalDirection == 0)
                    continue;

                return inputSource.HorizontalDirection;
            }

            return 0;
        }

        private bool IsJump => _inputSources.Any(source => source.Jump);
    }
}

