using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BombsGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (Transform children in this.transform)
        {
            i++;
        }

        Random rnd = new Random();
        for (int j = 0; j < 19; j++)
        {
            int x = rnd.Next(0, 64);
            this.transform.GetChild(x).tag ="Bomb";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
