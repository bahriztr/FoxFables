using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FoxFables.Inputs;
using FoxFables.Abstracts.Inputs;
using FoxFables.Movements;
using FoxFables.Animation;

namespace FoxFables.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Directional Values")]
        private float _horizontal;

        [Header("Booleans")]
        private bool _isJump;

        [Header("Instance Objects")]
        private IPlayerInput _input;
        private Mover _mover;
        private Jump _jump;
        private CharacterAnimation _characterAnimation;
        private Flip _flip;
        private OnGround _onGround;


        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _input = new PcInput();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
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
            _horizontal = _input.Horizontal;

            if (_input.IsJumpButtonDown && _onGround.IsOnGround)
            {
                _isJump = true;
            }
        }

        private void PlayerMovement()
        {
            _mover.HorizontalMovement(_horizontal);
            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.JumpAnimation(_jump.IsJumpAction && !_onGround.IsOnGround);
            _flip.FlipCharacter(_horizontal);
        }

        private void PlayerJump()
        {
            if(_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }

        }
    }
}
