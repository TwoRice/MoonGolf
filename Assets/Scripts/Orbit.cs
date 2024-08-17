using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private Rigidbody2D body2D;
    private Vector2 orbitVelocity;

    void Start() {
        body2D = GetComponent<Rigidbody2D>();
        GameObject orbitCentre = transform.parent.gameObject;

        float orbitMass = orbitCentre.GetComponent<Rigidbody2D>().mass;
        float r = Vector2.Distance(transform.position, orbitCentre.transform.position);
        Vector2 orbitDirection = new(-1, 0);
        orbitVelocity = orbitDirection * Mathf.Sqrt(orbitMass / r);
        InitiateOrbit();
    }

    public void InitiateOrbit() {
        body2D.velocity = orbitVelocity;
    }
}
