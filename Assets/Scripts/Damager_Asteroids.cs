using UnityEngine;

public class Damager_Asteroids : MonoBehaviour
{
    [SerializeField] float damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.TryGetComponent(out HealthObject_Asteroids ho))
        {
            ho.Damage(damage);
        }
        
    }

}
