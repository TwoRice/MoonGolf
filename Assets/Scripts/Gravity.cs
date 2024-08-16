using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float G = 1f;
    GameObject[] attractors;
    GameObject[] orbiters;
    
    void Start()
    {
        attractors = GameObject.FindGameObjectsWithTag("Attractor");
        orbiters = GameObject.FindGameObjectsWithTag("Orbiter");
    }

    void FixedUpdate()
    {
        foreach (GameObject a in attractors) {
            foreach (GameObject o in orbiters) {
                float attractor_mass = a.GetComponent<Rigidbody2D>().mass;
                float attraction = Vector2.Distance(a.transform.position, o.transform.position);

                Vector2 attraction_dir = (a.transform.position - o.transform.position).normalized;
                o.GetComponent<Rigidbody2D>().AddForce(attraction_dir * (G * attractor_mass) / (attraction * attraction));
            }
        }
    }
}
