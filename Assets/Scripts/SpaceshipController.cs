using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;

    [SerializeField] float angularSpeed = 180;
    [SerializeField] float acceleration = 10;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float drag = 1;
    [SerializeField] Transform[] guns;

    [SerializeField] GameObject projectile;

    int shots = 0;

    void OnValidate()
    {
        if(rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float vericalInput = Input.GetAxisRaw("Vertical");
        vericalInput = Mathf.Max(0, vericalInput);

        if (vericalInput > 0)
        {
            rigidBody.linearVelocity += (Vector2)transform.up * acceleration * Time.fixedDeltaTime;
            rigidBody.linearVelocity = Vector2.ClampMagnitude(rigidBody.linearVelocity, maxSpeed);
        }

        rigidBody.linearDamping = vericalInput > 0 ? 0 : drag;

        // rigidBody.linearVelocity *= 1 - (drag * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform gun = guns[shots % guns.Length];
            GameObject newProjectileGO = Instantiate(projectile, gun.position, gun.rotation);
            Projectile newProjectile = newProjectileGO.GetComponent<Projectile>();
            newProjectile.velocity += (Vector3) rigidBody.linearVelocity;
            shots++;
        }

        float horizomntalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -horizomntalInput * angularSpeed * Time.deltaTime);

        // transform.position += velocity * Time.deltaTime;
    }
}
