using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoxFables.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Force Values")]
        [SerializeField] private float speed;
        [SerializeField] private float _jumpForce;

        [Header("Directional Values")]
        private float _horizontal;

        [Header("Animation")]
        private Animator _anim;

        [Header("Components In Hierarchy")]
        private Rigidbody2D _rb;

        [Header("Booleans")]
        private bool _isJump;

        public bool IsJumpAction => _rb.velocity != Vector2.zero;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            InputProcess();
        }

        private void FixedUpdate()
        {
            PlayerMovement();
            PlayerJump();
        }

        private void InputProcess()
        {
            _horizontal = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                _isJump = true;
            }
        }

        private void PlayerMovement()
        {
            _anim.SetFloat("moveSpeed", Mathf.Abs(_horizontal));
            transform.Translate(Vector2.right * _horizontal * Time.deltaTime * speed);

            if(_horizontal != 0)
                transform.localScale = new Vector2(Mathf.Sign(_horizontal), 1);
        }

        private void PlayerJump()
        {
            if(_isJump)
            {
                _rb.AddForce(Vector2.up * _jumpForce);
                _isJump = false;
            }

            _anim.SetBool("isJump", IsJumpAction);
        }
    }
}
