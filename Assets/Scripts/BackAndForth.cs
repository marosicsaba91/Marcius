using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] Transform t1, t2;
    [SerializeField] float speed = 5;
    [SerializeField, Range(0,1)] float startPosition;
    [SerializeField] Color c1, c2;


    Transform currentTarget;

    void OnValidate()
    {
        if (t1 == null || t2 == null)
            return;
        
        transform.position = Vector3.Lerp(t1.position, t2.position, startPosition);
    }

    void Start()
    {
        transform.position = t1.position;

        currentTarget = t2;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime);

        if (transform.position == currentTarget.position)
        {
            Transform nextTarget = currentTarget == t1 ? t2 : t1;
            currentTarget = nextTarget;
        }
    }

    void OnDrawGizmos()
    {
        if (t1 == null || t2 == null)
            return;

        Gizmos.color = Color.Lerp(c1, c2, startPosition);
        Gizmos.DrawLine(t1.position, t2.position);
    }
}
