using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoxFables.Movements
{
    public class OnGround : MonoBehaviour
    {
        [Header("Foot Transforms")]
        [SerializeField] private Transform[] translates;

        [Header("Bools")]
        [SerializeField] private bool isOnGround = false;
        public bool IsOnGround => isOnGround;

        [Header("Raycast Values")]
        [SerializeField] private float maxDistance = 0.15f;
        [SerializeField] private LayerMask layerMask;


        private void Update()
        {
            foreach(Transform footTransform in translates)
            {
                CheckFootOnGround(footTransform);

                if (isOnGround) break;
            }
        }

        private void CheckFootOnGround(Transform footTransform)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, layerMask);
            Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);

            if (hit.collider != null)
                isOnGround = true;
            else
                isOnGround = false;
        }
    }
}
