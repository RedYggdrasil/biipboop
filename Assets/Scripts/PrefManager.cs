﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PrefManager 
{
    [HideInInspector]
    public static bool musicToggled = true;
    [HideInInspector]
    public static float soundVolume = 0.5f;
    [HideInInspector]
    public static bool triggerIntro = true;
    [HideInInspector]
    public static string currScene = "Menu";
}
