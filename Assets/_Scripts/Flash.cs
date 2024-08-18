using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] float interval = 0.5f;
    [SerializeField] float value1 = 0.6f;
    [SerializeField] float value2 = 0.3f;
    private Renderer objectRenderer;
    private Color originalColor;
    private bool tick = false;
    void Start() {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        InvokeRepeating("FlashOpacity", interval, interval);
    }

    void FlashOpacity() {
        Color newColor = originalColor;
        newColor.a = tick ? value1 : value2;
        objectRenderer.material.color = newColor;
        tick = !tick;
    }
}
