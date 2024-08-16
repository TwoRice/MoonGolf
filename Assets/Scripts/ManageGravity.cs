using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGravity : MonoBehaviour
{
    private GameObject[] attractors;

    void Start()
    {
        attractors = GameObject.FindGameObjectsWithTag("Attractor");
        foreach (GameObject a in attractors) {
            a.GetComponent<Gravity>().enabled = false;
        }

    }

    public void EnableGravity() {
        foreach (GameObject a in attractors) {
            a.GetComponent<Gravity>().enabled = true;
        }
    }
}
