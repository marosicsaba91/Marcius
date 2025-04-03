using UnityEngine;

public class Homework : MonoBehaviour
{
    [SerializeField] int n=10;

    void Start()
    {
        WritePrimes(n);
    }

    bool IsPrime(int number) 
    {
        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    void WritePrimes(int n) 
    {
        int count = 0;
        for (int i = 2; count < n; i++)
        {
            bool isPrime = IsPrime(i);
            if (isPrime)
            {
                Debug.Log(i);
                count++;
            }
        }        
    }
}
