using UnityEngine;

public class DecimalBinaryConverter : MonoBehaviour
{
    [SerializeField] int decimalNumber;
    [SerializeField] int binaryNumber;

    void OnValidate()
    {
         // binaryNumber = DecomalToBinary(decimalNumber);
    }

    int DecomalToBinary(int decimalNumber)
    {
        int digits = 0;
        int dn = decimalNumber;

        while (dn != 0)
        {
            dn /= 2;
            digits++;
        }

        int result = 0;
        while (digits > 0)
        {
            digits--;
            int digitValue = Pow(2, digits);
            int digit = decimalNumber / digitValue;
            result += Pow(10, digit);
        }
        return result;
    }

    int Pow(int baseNum, int exp) 
    {
        int result = 1;
        for (int i = 0; i < exp; i++)
            result *= baseNum;

        return result;
    }
}