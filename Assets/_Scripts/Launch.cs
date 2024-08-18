using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField] float launchSpeed = 10f;
    private ManageGravity manageGravity;
    
    private bool launched = false;
    private int shotsFired = 0;
    private Rigidbody2D body2D;
    private PlayerInputManager playerInput;
    private AudioSource soundEffect;
    private TextMeshProUGUI shotsText;
    
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInputManager>();
        manageGravity = GameObject.FindGameObjectWithTag("GravityManager").GetComponent<ManageGravity>();
        soundEffect = GetComponent<AudioSource>();
        shotsText = GameObject.FindGameObjectWithTag("ShotsText")?.GetComponent<TextMeshProUGUI>();
    }

    public void ResetLaunch() {
        launched = false;
    }

    public void PlayLaunchSound() {
        float pitch = Random.Range(0.6f, 1.8f);
        soundEffect.pitch = pitch;
        soundEffect.Play(0);
    }

    void Update()
    {
        if (playerInput.Shoot && launched == false) {
            launched = true;
            manageGravity.DisableInitialGravity();
            manageGravity.EnableGravity();
            Vector2 currentDirection = body2D.velocity.normalized;
            body2D.velocity += currentDirection * launchSpeed;

            PlayLaunchSound();
            shotsFired++;
            if (shotsText) {
                shotsText.SetText("Shots: " + shotsFired);
            }
        }
    }
}
