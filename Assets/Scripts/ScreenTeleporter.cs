using UnityEngine;

public class ScreenTeleporter : MonoBehaviour
{
    Camera cam;
    Collider2D coll;

    void Start()
    {
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        Rect cameraRect = CameraUtility.GetRect(cam);
        Rect objRect = GetObjectRect();
        Vector2 pos = transform.position;

        // Homework: Amikor teljesen kiértem egyik oldalon, akkor éppenhogy beérjel a másik oldalon.
        if (!cameraRect.Overlaps(objRect))
        {
            Vector2 jump = Vector2.zero;

            if (pos.x < cameraRect.xMin)
                jump += Vector2.right * cameraRect.width;
            if (pos.x > cameraRect.xMax)
                jump += Vector2.left * cameraRect.width;
            if (pos.y < cameraRect.yMin)
                jump += Vector2.up * cameraRect.height;
            if (pos.y > cameraRect.yMax)
                jump += Vector2.down * cameraRect.height;

            transform.position += (Vector3)jump;
        }
    }

    Rect GetObjectRect()
    {
        if (coll == null)
            coll = GetComponent<Collider2D>();

        Bounds bounds = coll.bounds;
        return new Rect(bounds.min, bounds.size);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Rect objRect = GetObjectRect();

        Gizmos.DrawWireCube(objRect.center, objRect.size);
    }
}
