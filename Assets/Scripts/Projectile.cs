using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 25;
    [SerializeField] float lifeTime = 2;
    [NonSerialized] public Vector3 velocity;

    float timer;

    void Start()
    {
        velocity += transform.up * speed;

        timer = 0;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= lifeTime)
            Destroy(gameObject);    
    }
}
