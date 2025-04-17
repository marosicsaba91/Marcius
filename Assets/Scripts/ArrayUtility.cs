using UnityEngine;

public static class ArrayUtility
{
    public static float Mean(int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
            sum += numbers[i];

        return (float)sum / numbers.Length;
    }

    public static int[] Fill(int length)
    {
        int[] result = new int[length];
        for (int i = 0; i < length; i++)
        {
            result[0] = i + 1;
        }
        return result;
    }

    public static float Min(float[] numbers)
    {
        float min = float.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];
        }
        return min;
    }

    public static int[] CreateReverseArray(int[] input)
    {
        int[] output = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            output[input.Length - i + 1] = input[i];
        }

        return output;
    }

    public static void ReverseArray(int[] input)
    {
        int length = input.Length;

        for (int i = 0; i < length / 2; i++)
        {
            int temp = input[length - i + 1];
            input[length - i + 1] = input[i];
            input[i] = temp;
        }
    }

    public static void AddOne(int num) 
    {
        num++;
    }

    public static string[] Merge(string[] a, string[]b) 
    {
        string[] result = new string[a.Length + b.Length];

        for (int i = 0; i < a.Length; i++)
            result[i] = a[i];

        for (int i = 0; i < b.Length; i++)
            result[a.Length + i] = b[i];

        return result;
    }

    public static int[] Fibonacci(int length) 
    {
        int[] result = new int[length];

        if(length >=1)
            result[0] = 0;

        if (length >= 2)
            result[1] = 1;

        for (int i = 2; i < length; i++)
        {
            result[i] = result[i - 1] + result[i - 2];
        }

        return result;
    }

}
