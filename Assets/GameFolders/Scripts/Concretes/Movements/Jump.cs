using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoxFables.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [Header("Components")]
        private Rigidbody2D _rb;

        [Header("Force Values")]
        [SerializeField] private float _jumpForce = 350f;

        public bool IsJumpAction => _rb.velocity != Vector2.zero;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void JumpAction()
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }
}
