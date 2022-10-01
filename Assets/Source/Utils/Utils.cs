using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void Shuffle<T>(this IList<T> List)
    {
        for (int i = 0; i < List.Count; i++)
        {
            int valueToSwap = Random.Range(i, List.Count - i);

            T temp = List[i];
            List[i] = List[valueToSwap];
            List[valueToSwap] = temp;
        }
    }
}
