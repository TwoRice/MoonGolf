using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private bool random = false;
    public float rotationSpeed = 30f;
    public bool rotateLeft = true; 
    private int direction;

    void Start() {
        if (random) {
            rotationSpeed = Random.Range(10, 40);
            rotateLeft = Random.Range(0, 1.01f) > 0.5f;
        }
        direction = rotateLeft ? -1: 1;
    }

    void Update(){
        transform.Rotate(direction * Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
