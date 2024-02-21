using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FoxFables.Abstracts.Inputs;

namespace FoxFables.Inputs
{
    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}
