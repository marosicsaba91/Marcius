using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField] float startHealth = 100;
    [SerializeField] Behaviour toDisable;
    [SerializeField] Renderer toDisableRendere;
    [SerializeField] Rigidbody[] toEnable;

    [SerializeField] Color deadColor = Color.white;

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
            OnDeath();
    }

    void OnDeath()
    {
        if(toDisable != null)
            toDisable.enabled = false;

        if (toDisableRendere != null)
            toDisableRendere.enabled = false;

        foreach (var item in toEnable)
        {
            item.gameObject.SetActive(true);
            Vector3 force = (item.position - transform.position) * 2 + Vector3.up;
            force *= 5;
            item.AddForce(force, ForceMode.Impulse);
        }

        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material m = mr.material;
        m.color = deadColor;
    }
}