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
            AudioSource soundEffect = collisionInfo.gameObject.GetComponent<AudioSource>();
            Debug.Log(soundEffect);
            if (soundEffect){
                soundEffect.Play(0);
            }
            reset.ResetMoon();
        }
    }
}
