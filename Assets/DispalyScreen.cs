﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispalyScreen : MonoBehaviour
{
    void Awake()
    {
        for (int i = 0; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
            Screen.SetResolution(Display.displays[i].renderingWidth, Display.displays[i].renderingHeight, true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
