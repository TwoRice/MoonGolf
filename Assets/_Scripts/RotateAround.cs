using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform rotateCentre;
    [SerializeField] private float speed;

    void Update(){
        transform.RotateAround(rotateCentre.position, Vector3.forward, speed * Time.deltaTime);
    }
}
