using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid[] startAsteroids;
    [SerializeField] int startAsteroidCount = 5;
    [SerializeField] float colliderDelay = 1;
    [SerializeField] float minStartSpeed, maxStartSpeed;
    [SerializeField] float maxAngularSpeed;

    [SerializeField] int randomSeed;

    public static List<Asteroid> allAsteroids = new();
    float colliderTimer;


    void Start()
    {
        System.Random random = new(randomSeed);

        for (int i = 0; i < startAsteroidCount; i++)
        {
            int randomIndex = random.Next(0, startAsteroids.Length);
            Asteroid prototype = startAsteroids[randomIndex];

            Vector2 startPoint = CameraUtility.GetRandomPointInCamera(Camera.main, random);
            Quaternion startRotation = Quaternion.Euler(0, 0, (float)random.NextDouble() * 360);

            Asteroid newAsteroid = Instantiate(prototype, startPoint, startRotation, transform);

            float speed =(float)random.NextDouble();
            speed = Mathf.Lerp(minStartSpeed, maxStartSpeed, speed);
            Vector2 randomDir = Random.insideUnitCircle.normalized;

            float angularSpeed = (float)random.NextDouble();
            angularSpeed = Mathf.Lerp(-maxAngularSpeed, maxAngularSpeed, angularSpeed);

            newAsteroid.SetVelocity(randomDir * speed, angularSpeed);
        }
        colliderTimer = colliderDelay;
        DisableColision();
    }

    void Update()
    {
        if (colliderTimer != -1)
        {
            colliderTimer -= Time.deltaTime;

            if (colliderTimer <= 0)
            {
                EnableColision();
                colliderTimer = -1;
            }
        }
    }

    void DisableColision() { EnableColision(false); }

    void EnableColision(bool enable = true)
    {
        for (int i = 0; i < allAsteroids.Count; i++)
        {
            for (int j = i + 1; j < allAsteroids.Count; j++)
            {
                Collider2D c1 = allAsteroids[i].GetComponent<Collider2D>();
                Collider2D c2 = allAsteroids[j].GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(c1, c2, !enable);
            }
        }
    }

    public int GetAsteroidCount()
    {
        return allAsteroids.Count;
    }
}
