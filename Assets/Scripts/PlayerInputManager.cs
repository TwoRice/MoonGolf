using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerInputManager : MonoBehaviour
{
    public bool Shoot {get; private set;}
    public bool Reset {get; private set;}

    void Update()
    {
        Shoot = Input.GetButtonDown("Fire1");
        Reset = Input.GetKeyDown(KeyCode.R);
    }
}