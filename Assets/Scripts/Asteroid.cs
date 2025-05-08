using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float damage = 20;
    [SerializeField] Rigidbody2D rigidBody;

    void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 velocity, float angularValocity) 
    {
        rigidBody.linearVelocity = velocity;
        rigidBody.angularVelocity = angularValocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        const float minimalSpeedToDamage = 0.1f;
        if (collision.relativeVelocity.magnitude > minimalSpeedToDamage)  // Csúnya
        {
            if (collision.gameObject.TryGetComponent(out HealthObject_Asteroids ho))
                ho.Damage(Random.Range(0f, damage));
        }
    }

    void OnEnable()
    {
        AsteroidManager.allAsteroids.Add(this);
    }

    void OnDisable()
    {
        AsteroidManager.allAsteroids.Remove(this);
    }
}
