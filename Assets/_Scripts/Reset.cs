using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1f;
    private PlayerInputManager playerInput;
    private ManageGravity manageGravity;
    private Launch launch;
    private Orbit orbit;
    private TrailRenderer trail;

    void Start() {
        playerInput = GetComponent<PlayerInputManager>();
        manageGravity = GameObject.FindGameObjectWithTag("GravityManager").GetComponent<ManageGravity>();
        launch = GetComponent<Launch>();
        orbit = GetComponent<Orbit>();
        trail = GetComponent<TrailRenderer>();
    }

    public void ResetMoon() {
        StartCoroutine(ResetMoonCo());
    }
    
    IEnumerator ResetMoonCo() {
        trail.enabled = false;
        manageGravity.DisableGravity();
        yield return StartCoroutine(MoveOverTime(new Vector3(0, 0, 0), new Vector3(0, 2, 0)));
        orbit.InitiateOrbit();
        manageGravity.EnableInitialGravity();
        launch.ResetLaunch();
        trail.enabled = true;
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
        if (playerInput.Reset && launch.Launched) {
            ResetMoon();
        }
        if (playerInput.HardReset) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
