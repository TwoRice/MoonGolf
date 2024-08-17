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
        yield return StartCoroutine(MoveOverTime(new Vector3(0, 0, 0), new Vector3(0, 2, 0)));
        orbit.InitiateOrbit();
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
            StartCoroutine(ResetMoon());
        }
        
    }
}
