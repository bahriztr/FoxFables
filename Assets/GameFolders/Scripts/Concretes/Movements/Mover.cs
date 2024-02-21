using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoxFables.Movements
{
    public class Mover : MonoBehaviour
    {
        [Header("Force Values")]
        [SerializeField] private float speed = 5f;

        public void HorizontalMovement(float horizontal)
        {
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        }
    }
}
