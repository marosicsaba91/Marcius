using System;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField] float startHealth;

    float health;

    void Start()
    {
        health = startHealth;
    }

    public void Damage(float damage)
    {
        if (health <= 0)
            return;

        health -= damage;

        if (health <= 0)
            Debug.Log("I'm dead!");
    }

}
