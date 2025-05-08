using UnityEngine;

public class HealthObject_Asteroids : MonoBehaviour
{
    [SerializeField] float startHp;

    float hp;

    public float GetHP() { return hp; }
    public float GetStartHp() { return startHp; }

    void Start()
    {
        hp = startHp;
    }

    public void Damage(float damage)
    {
        if (hp <= 0)
            return;

        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }
}
