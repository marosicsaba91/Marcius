using UnityEngine;

public class SwingSword : MonoBehaviour
{
    [SerializeField] Transform rotateable;
    [SerializeField] AnimationCurve angleOverTime;
    [SerializeField, Range(0, 1)] float testPhase;
    [SerializeField, Min(0)] float animDuration = 0.5f;
    [SerializeField] Collider swordCollider;

    [SerializeField] KeyCode key = KeyCode.Space;

    float timer;

    void OnValidate()
    {
        if (rotateable == null)
            return;

        SetAngle(testPhase);
    }

    void SetAngle(float phase)
    {
        Vector3 euler = rotateable.rotation.eulerAngles;
        euler.x = angleOverTime.Evaluate(phase);
        rotateable.rotation = Quaternion.Euler(euler);
    }

    void Update()
    {
        if (timer == 0 && Input.GetKeyDown(key))
        {
            timer = animDuration;
        }

        SetAngle(1 - (timer / animDuration));

        timer -= Time.deltaTime;
        timer = Mathf.Max(0, timer);

        swordCollider.enabled = timer != 0;
    }

}
