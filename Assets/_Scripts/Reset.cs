using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1f;
    private PlayerInputManager playerInput;
    private ManageGravity manageGravity;
    private Launch launch;
    private Orbit orbit;

    void Start() {
        playerInput = GetComponent<PlayerInputManager>();
        manageGravity = GameObject.FindGameObjectWithTag("GravityManager").GetComponent<ManageGravity>();
        launch = GetComponent<Launch>();
        orbit = GetComponent<Orbit>();
    }

    public void ResetMoon() {
        StartCoroutine(ResetMoonCo());
    }
    
    IEnumerator ResetMoonCo() {
        manageGravity.DisableGravity();
        yield return StartCoroutine(MoveOverTime(new Vector3(0, 0, 0), new Vector3(0, 2, 0)));
        orbit.InitiateOrbit();
        manageGravity.EnableInitialGravity();
        launch.ResetLaunch();
    }

    IEnumerator MoveOverTime(Vector3 start, Vector3 end) {
        float elapsed = 0f;

        while (elapsed < animationDuration) {
            transform.localPosition = Vector3.Lerp(start, end, elapsed / animationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;
    }
    
    void Update() {
        if (playerInput.Reset) {
            ResetMoon();
        }
        
    }
}
