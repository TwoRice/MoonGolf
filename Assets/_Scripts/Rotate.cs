using UnityEngine;

public class Rotate2DObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;

    void Update(){
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
