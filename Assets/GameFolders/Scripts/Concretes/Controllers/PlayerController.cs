using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoxFables.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        }
    }
}
