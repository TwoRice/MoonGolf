using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNumber : MonoBehaviour
{
    void Start() {
        GetComponent<TextMeshProUGUI>().SetText("Level" + (SceneManager.GetActiveScene().buildIndex) + "/5");
    }
}
