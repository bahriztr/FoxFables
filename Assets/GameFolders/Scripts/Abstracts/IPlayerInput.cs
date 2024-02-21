using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoxFables.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        bool IsJumpButtonDown { get; }
    }
}
