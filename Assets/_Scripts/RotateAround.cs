using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    Left,
    Right

}

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform rotateCentre;
    [SerializeField] private float speed;
    [SerializeField] Direction direction;

    void Update(){
        Vector2 dir = direction == Direction.Left ? new Vector3(0, 0, -1) : new Vector3(0, 0, 1); 
        transform.RotateAround(rotateCentre.position, Vector3.forward, speed * Time.deltaTime);
    }
}
