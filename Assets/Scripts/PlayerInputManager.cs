using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputManager : MonoBehaviour
{
    public bool Shoot {get; private set;}

    void Update()
    {
        Shoot = Input.GetButtonDown("Fire1");
    }
}