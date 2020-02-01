﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRad);
        Vector3 viewingAngleA = fov.DirFromAngle(-fov.viewAngle/2, false);
        Vector3 viewingAngleB = fov.DirFromAngle(fov.viewAngle/2, false);
        Handles.DrawLine(fov.transform.position, fov.transform.position+viewingAngleA*fov.viewRad);
        Handles.DrawLine(fov.transform.position, fov.transform.position+viewingAngleB*fov.viewRad);

        Handles.color = Color.blue;
        foreach (Transform visibleTarget in fov.visibleTargets) 
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }
    }
}
