using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGravity : MonoBehaviour
{
    private GameObject initialAttractor;
    private GameObject[] attractors;

    void Start()
    {
        initialAttractor = GameObject.FindGameObjectWithTag("InitialAttractor");
        attractors = GameObject.FindGameObjectsWithTag("Attractor");
        DisableGravity();
    }

    public void EnableInitialGravity() {
        initialAttractor.GetComponent<Gravity>().enabled = true;
    }
    
    public void EnableGravity() {
        foreach (GameObject a in attractors) {
            a.GetComponent<Gravity>().enabled = true;
        }
    }

    public void DisableGravity(bool disableInitialAttractor=false) {
        if (disableInitialAttractor) {
            initialAttractor.GetComponent<Gravity>().enabled = false;
        }

        foreach (GameObject a in attractors) {
            a.GetComponent<Gravity>().enabled = false;
        }
    }
}
