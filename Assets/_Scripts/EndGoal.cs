using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    private AudioSource soundEffect;
    private bool isComplete = false;
    private int nextLevelIndex;

    void Start() {
        soundEffect = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if (!isComplete) {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            nextLevelIndex = currentLevelIndex == 5 ? 0 : currentLevelIndex + 1;
            collisionInfo.gameObject.SetActive(false);
            if (soundEffect != null) {
                StartCoroutine(CompleteLevel());
            }
            else {
                SceneManager.LoadScene(nextLevelIndex);
            }
        }
    }

    IEnumerator CompleteLevel() {
        isComplete = true;
        endScreen.SetActive(true);
        soundEffect.Play(0);
        yield return new WaitWhile(() => soundEffect.isPlaying);
        endScreen.SetActive(false);
        SceneManager.LoadScene(nextLevelIndex);
    }
}
