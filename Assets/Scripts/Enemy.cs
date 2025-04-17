using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float smoothMovementTime = 1; 
    [SerializeField] float standingTime = 1;
    [SerializeField] float shootDelay = 3;
    [SerializeField] Projectile projectile;

    Vector2 targetPoint;

    float standingTimer;
    float shootingTimer;

    Vector2 velocity;

    void Start()
    {
        SelectRandomPoint();
        shootingTimer = shootDelay;
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        Vector2 pos = (Vector2)transform.position;

        if (standingTimer <= 0)
        {
            const float epsilon = 0.01f;
            if (Vector2.Distance(pos, targetPoint) > epsilon)
                transform.position = Vector2.SmoothDamp(pos, targetPoint, ref velocity, smoothMovementTime);
            else
            {
                standingTimer = standingTime;
                SelectRandomPoint();
            }
        }
        else
        {
            standingTimer -= Time.deltaTime;
        }
    }

    void HandleShooting()
    {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0)
        {
            SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
            Vector3 playerPoint = player.transform.position;
            Vector3 direction = playerPoint - transform.position;
            float angle = Vector3.SignedAngle(direction, Vector3.up, -Vector3.forward);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Projectile newProjectile = Instantiate(projectile, transform.position, rotation);
            shootingTimer += shootDelay;
        }
    }

    void SelectRandomPoint()
    {
        Rect cameraRect = CameraUtility.GetRect(Camera.main);
        targetPoint = GetRandomPoint(cameraRect);
    }

    static Vector2 GetRandomPoint(Rect rect)
    {
        float x = Random.Range(rect.xMin, rect.xMax);
        float y = Random.Range(rect.yMin, rect.yMax);
        return new(x, y);
    }
}
