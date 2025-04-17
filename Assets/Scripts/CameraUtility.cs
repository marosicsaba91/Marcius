using UnityEngine;

public static class CameraUtility 
{
    public static Rect GetRect(Camera cam)
    {
        float h = cam.orthographicSize;
        Vector2 center = cam.transform.position;
        Vector2 extent = new(h * cam.aspect, h);
        Rect cameraRect = new(center - extent, extent * 2);
        return cameraRect;
    }
}
