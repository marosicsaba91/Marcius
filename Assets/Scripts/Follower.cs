using UnityEngine;

public class Follower : MonoBehaviour
{
    /*
    [SerializeField] float minRange = 5;
    [SerializeField] float maxRange = 10;

    [SerializeField] float minSpeed = 0;
    [SerializeField] float maxSpeed = 10;
    */

    [SerializeField] Transform target;
    [SerializeField] AnimationCurve distanceOverSpeed;

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        /*
        float t = Mathf.InverseLerp(maxRange, minRange, distance);
        float speed = Mathf.Lerp(minSpeed, maxSpeed, t);
        Debug.Log($"T: {t}    Speed: {speed}");
        */

        float speed = distanceOverSpeed.Evaluate(distance);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    /*
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, minRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
    */
}