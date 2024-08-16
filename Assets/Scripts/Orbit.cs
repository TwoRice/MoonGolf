using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] GameObject orbitCentre;


    void Start() {
        Rigidbody2D body2D = GetComponent<Rigidbody2D>();

        float orbitMass = orbitCentre.GetComponent<Rigidbody2D>().mass;
        float r = Vector2.Distance(transform.position, orbitCentre.transform.position);
        
        Vector2 orbitDirection = new Vector2(-1, 0);
        body2D.velocity += orbitDirection * Mathf.Sqrt(orbitMass / r);
    }
}
