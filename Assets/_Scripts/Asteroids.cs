using UnityEngine;

public enum FillShape {
    Rectangle,
    Doughnut
}

public class Asteroids : MonoBehaviour
{
    [SerializeField] private int randomSeed;
    [SerializeField] private GameObject asteroid;
    [SerializeField] private int numberAsteroids = 10;
    [SerializeField] private FillShape shape = FillShape.Rectangle;

    void Start()
    {
        Random.InitState(randomSeed);
        
        if (shape == FillShape.Rectangle) {
            PlaceInRectangle();
        } else if (shape == FillShape.Doughnut) {
            PlaceInDoughnut();
        }
    }

    private void PlaceInRectangle() {
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

    private void PlaceInDoughnut() {
        Vector3 pos = transform.position;
        Vector3 localScale = transform.localScale;

        Vector3 min = new(pos.x - localScale.x / 2, pos.y - localScale.y / 2, pos.z);
        Vector3 max = new(pos.x + localScale.x / 2, pos.y + localScale.y / 2, pos.z);

        for (int i = 0; i < numberAsteroids; i++)
        {
            GameObject newAsteroid = Instantiate(asteroid);

            float angle = Random.Range(0, 2 * Mathf.PI);
            float radius = Random.Range(3f, 4f);

            float X = pos.x + radius * Mathf.Cos(angle);
            float Y = pos.y + radius * Mathf.Sin(angle);
            float scale = Random.Range(1f, 1.3f);
            float rotation = Random.Range(0f, 360f);

            newAsteroid.transform.position   = new Vector3(X, Y, 0);
            newAsteroid.transform.localScale = new Vector3(scale, scale, 1);
            newAsteroid.transform.Rotate(Vector3.forward * rotation);
        }
    }
}
