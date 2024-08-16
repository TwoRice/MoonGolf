using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private GameObject moon;
    private Rigidbody2D moonBody2D;
    private Rigidbody2D body2D;
    
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        moon = GameObject.FindWithTag("Orbiter");
        moonBody2D = moon.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float attractionForce = Vector2.Distance(transform.position, moon.transform.position);

        Vector2 attraction_dir = (transform.position - moon.transform.position).normalized;
        moonBody2D.AddForce((attraction_dir * body2D.mass) / (attractionForce * attractionForce));
    }
}
