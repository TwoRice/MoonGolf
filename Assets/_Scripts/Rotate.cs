using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;

    void Update(){
        transform.Rotate(-1 * Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
