using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoxFables.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Animator _anim;
        private float _horizontal;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            InputProcess();
        }

        private void FixedUpdate()
        {
            PlayerMovement();
        }

        private void InputProcess()
        {
            _horizontal = Input.GetAxis("Horizontal");
        }

        private void PlayerMovement()
        {

            _anim.SetFloat("moveSpeed", Mathf.Abs(_horizontal));
            transform.Translate(Vector2.right * _horizontal * Time.deltaTime * speed);

            if(_horizontal != 0)
                transform.localScale = new Vector2(Mathf.Sign(_horizontal), 1);
        }
    }
}
