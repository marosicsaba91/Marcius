using UnityEngine;

public class PoseSaver : MonoBehaviour
{
    const string poseKey = "Pose";

    void Awake()
    {
        if (!ObjectSaver.HaveFileToLoad(poseKey))
            return;

        Pose p = ObjectSaver.LoadFromFile<Pose>(poseKey);

        transform.SetPositionAndRotation(p.position, p.rotation);
    }

    void OnDestroy()
    {
        // Mentés
        Pose pose = new(transform.position, transform.rotation);

        ObjectSaver.SaveToFile(poseKey, pose);
    }

}
