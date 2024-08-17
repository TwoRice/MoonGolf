using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
