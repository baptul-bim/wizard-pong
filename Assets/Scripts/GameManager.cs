using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static float globalSpeedMod = 1;

    // Start is called before the first frame update
    void Start()
    {
        globalSpeedMod = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (globalSpeedMod > 3)
        {
            globalSpeedMod = 3;
        }
    }
}
