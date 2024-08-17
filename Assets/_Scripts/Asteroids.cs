using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private int randomSeed;
    [SerializeField] private GameObject asteroid;
    [SerializeField] private int numberAsteroids = 10;

    void Start()
    {
        Random.InitState(randomSeed);
        
        Vector3 pos = transform.position;
        Vector3 localScale = transform.localScale;

        Vector3 min = new(pos.x - localScale.x / 2, pos.y - localScale.y / 2, pos.z);
        Vector3 max = new(pos.x + localScale.x / 2, pos.y + localScale.y / 2, pos.z);

        for (int i = 0; i < numberAsteroids; i++)
        {
            GameObject newAsteroid = Instantiate(asteroid);

            float X = Random.Range(min.x, max.x);
            float Y = Random.Range(min.y, max.y);
            float scale = Random.Range(1, 1.3f);
            float rotation = Random.Range(0, 360);

            newAsteroid.transform.position   = new Vector3(X, Y, 0);
            newAsteroid.transform.localScale = new Vector3(scale, scale, 1);
            newAsteroid.transform.Rotate(Vector3.forward * rotation);
        }
    }
}
