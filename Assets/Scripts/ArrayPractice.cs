using System.Collections.Generic;
using UnityEngine;

public class ArrayPractice : MonoBehaviour
{
    [SerializeField] int[] testIntArray;
    [SerializeField] Vector3[] testVectorArray;
    [SerializeField] GameObject[] testGameObjectArray;
    [SerializeField] List<string> testStringList;

    void Start()
    {
        List<string> stringList = new();

        stringList.Add("Alma");
        stringList.Add("Barack");
        stringList.Add("Citrom");
        
        List<string> stringList2 = new();

        stringList2.Add("Körte");
        stringList2.AddRange(stringList);

        int count = stringList2.Count;

        string st = stringList2[2];

        stringList2.RemoveAt(2);
        
        stringList2.Remove("Banán");  // ???
        stringList2.Insert(2, "Mangó");

        if (stringList2.Contains("Banán"))
            Debug.Log("Benne van");

        int index = stringList2.IndexOf("Alma");

        stringList2.Sort();
        stringList2.Reverse();

    }
}
