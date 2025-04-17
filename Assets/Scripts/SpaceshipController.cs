using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float angularSpeed = 180;
    [SerializeField] float acceleration = 10;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float drag = 1;

    [SerializeField] GameObject projectile;

    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        float vericalInput = Input.GetAxisRaw("Vertical");
        vericalInput = Mathf.Max(0, vericalInput);

        if (vericalInput > 0)
        {
            velocity += transform.up * acceleration * Time.fixedDeltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
            velocity *= 1 - (drag * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newProjectileGO = Instantiate(projectile, transform.position, transform.rotation);
            Projectile newProjectile = newProjectileGO.GetComponent<Projectile>();
            newProjectile.velocity += velocity;
        }

        float horizomntalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -horizomntalInput * angularSpeed * Time.deltaTime);

        transform.position += velocity * Time.deltaTime;
    }
}
