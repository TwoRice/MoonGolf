using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField] float launchSpeed = 10f;
    
    private bool launched = false;
    private Rigidbody2D body2D;
    private PlayerInputManager playerInput;
    
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInputManager>();
    }

    void Update()
    {
        if (playerInput.Shoot && launched == false) {
            launched = true;
            Vector2 currentDirection = body2D.velocity.normalized;
            body2D.velocity += currentDirection * launchSpeed;
        }
    }
}
