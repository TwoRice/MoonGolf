using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    private AudioSource soundEffect;
    private bool isComplete = false;

    void Start() {
        soundEffect = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if (!isComplete) {
            collisionInfo.gameObject.SetActive(false);
            StartCoroutine(CompleteLevel());
        }
    }

    IEnumerator CompleteLevel() {
        isComplete = true;
        soundEffect.Play(0);
        yield return new WaitWhile(() => soundEffect.isPlaying);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
