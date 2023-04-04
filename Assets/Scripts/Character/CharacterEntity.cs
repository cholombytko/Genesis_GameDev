using Unity.VisualScripting;
using UnityEngine;

namespace Character {

    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterEntity : MonoBehaviour
    {
        [Header("HorizontalMovement")] [SerializeField]
        private float _horizontalSpeed;

        [SerializeField] private bool _faceRight;

        [Header("Jump")] [SerializeField] private float _jumpForce;
        [SerializeField] private float _gravityScale;
        [SerializeField] private LayerMask _ground;
        [SerializeField] private Transform legs;


        private Rigidbody2D _rigidbody;

        public static bool IsJumping;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            IsJumping = !Physics2D.OverlapCircle(legs.position, 0.2f, _ground);
        }

        public void MoveHorizontally(float direction)
        {
            SetDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _horizontalSpeed;
            _rigidbody.velocity = velocity;
        }

        public void Jump()
        {
            if (IsJumping)
                return;

            IsJumping = true;
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _rigidbody.gravityScale = _gravityScale;
        }

        private void SetDirection(float direction)
        {
            if((_faceRight && direction < 0) || (!_faceRight && direction > 0))
            {
                Flip();
            }
        }

        private void Flip()
        {
            transform.Rotate(0, 180, 0);
            _faceRight = !_faceRight;
        }
    }
}
