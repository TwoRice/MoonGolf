using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private float scrollTime = 10f;
    private MeshRenderer mr;
    private Material mat;
    private static ScrollBackground instance;

    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }
    
    void Update()
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime / scrollTime;
        mat.mainTextureOffset = offset;
    }
}
