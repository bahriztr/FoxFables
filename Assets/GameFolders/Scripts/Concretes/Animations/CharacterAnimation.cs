using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoxFables.Animation
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        [Header("Animation")]
        private Animator _anim;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        public void MoveAnimation(float horizontal)
        {
            float absValue = Mathf.Abs(horizontal);

            if (_anim.GetFloat("moveSpeed") == absValue) return;

            _anim.SetFloat("moveSpeed", absValue);
        }

        public void JumpAnimation(bool isJump)
        {
            if (isJump == _anim.GetBool("isJump")) return;
            _anim.SetBool("isJump", isJump);
        }
    }
}
