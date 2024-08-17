using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1f;
    private PlayerInputManager playerInput;
    private ManageGravity manageGravity;
    private Orbit orbit;

    void Start() {
        playerInput = GetComponent<PlayerInputManager>();
        manageGravity = GameObject.FindGameObjectWithTag("GravityManager").GetComponent<ManageGravity>();
        orbit = GetComponent<Orbit>();
    }

    public IEnumerator ResetMoon() {
        manageGravity.DisableGravity(disableInitialAttractor: true);
        yield return StartCoroutine(MoveOverTime(new Vector3(0, -0.35f, 0), new Vector3(0, 2, 0), new Vector3(1, 0, 0)));
        orbit.InitiateOrbit();
        manageGravity.EnableInitialGravity();
    }

    IEnumerator MoveOverTime(Vector3 start, Vector3 end, Vector3 control) {
        float elapsed = 0f;

        while (elapsed < animationDuration) {
            float t = elapsed / animationDuration;
            Vector3 position = Mathf.Pow(1 - t, 2) * start + 2 * (1 - t) * t * control + Mathf.Pow(t, 2) * end;
            transform.localPosition = position;
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;
    }
    
    void Update() {
        if (playerInput.Reset) {
            StartCoroutine(ResetMoon());
        }
        
    }
}
