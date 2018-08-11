using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour {

    public static int PercentageBasedRandom(int size, int[] percentages)
    {
        if (size != percentages.Length)
        {
            Debug.LogError("Percentages and Choices must be the same Length");
            return -1;
        }
        int full = 0;
        foreach (int i in percentages)
        {
            full += i;
        }
        if (full != 100)
        {
            Debug.LogError("Percentages must add up to 100");
            return -1;
        }

        int length = size;
        float randomInt = Random.Range(0, 101);
        int holder = 0;
        int choice = -1;

        for (int i = 0; i < length; i++)
        {
            if (randomInt >= holder && randomInt <= percentages[i] + holder)
                choice = i;
            holder += percentages[i];
        }


        return choice;
    }
}
