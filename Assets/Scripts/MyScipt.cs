using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScipt : MonoBehaviour {

    public static GameObject PercentageBasedRandom(GameObject[] choices, int[] percentages)
    {
        if (choices.Length != percentages.Length)
        {
            Debug.LogError("Percentages and Choices must be the same Length");
            return null;
        }
        int full = 0;
        foreach (int i in percentages)
        {
            full += i;
        }
        if (full != 100)
        {
            Debug.LogError("Percentages must add up to 100");
            return null;
        }

        int length = choices.Length;
        float randomInt = Random.Range(0, 101);
        int holder = 0;
        GameObject choice = null;

        for (int i = 0; i < length; i++)
        {
            if (randomInt >= holder && randomInt <= percentages[i] + holder)
                choice = choices[i];
            holder += percentages[i];
        }


        return choice;
    }
}
