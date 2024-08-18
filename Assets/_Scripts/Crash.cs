using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    private Reset reset;
    private ParticleSystem explode;
    
    void Start(){
        reset = GetComponent<Reset>();
        explode = GameObject.FindGameObjectWithTag("Explosion").GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo){
        if (collisionInfo.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
            // Play Sound Effect
            AudioSource soundEffect = collisionInfo.gameObject.GetComponent<AudioSource>();
            if (soundEffect){
                soundEffect.Play(0);
            }
            
            // Play Particle Effect
            if (!collisionInfo.gameObject.CompareTag("InitialAttractor")) {
                explode.transform.position = collisionInfo.contacts[0].point;
                explode.Play();
            }

            // Reset
            reset.ResetMoon();
        }
    }
}
