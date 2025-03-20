using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new(hInput, 0, vInput);
        direction.Normalize();
        // Comment

        Vector3 velocity = direction * speed;

        transform.position += velocity * Time.deltaTime;
    }
}
