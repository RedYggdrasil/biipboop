using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalHud : MonoBehaviour
{
    public GameObject Activity;
    public float progressValue;
    public Image progressBar;
    public Transform cam;

    void Update() 
    {
        transform.LookAt(cam.position);
    }

    void UpdateProgress(float newProgress)
    {
        progressBar.fillAmount = newProgress;
        progressValue = newProgress;
    }
}
