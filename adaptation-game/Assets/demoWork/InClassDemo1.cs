using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InClassDemo1 : MonoBehaviour
{
    public int[] mountainHeights = { 1, 4, 2, 7, 5, 4, 1 };
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighestNum();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int HighestNum()
    {
        int max = 0;

        for (int i = 0; i < mountainHeights.Length; i++)
        {
            if (max < mountainHeights[i])
            {
                max = mountainHeights[i];
            }
        }

        return max;
    }
}
