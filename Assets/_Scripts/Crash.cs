using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    private Reset reset;
    
    void Start(){
        reset = GetComponent<Reset>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo){
        if (collisionInfo.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
            collisionInfo.gameObject.GetComponent<AudioSource>()?.Play(0);
            reset.ResetMoon();
        }
    }
}
