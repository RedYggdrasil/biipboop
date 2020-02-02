using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalHud : MonoBehaviour
{
    public float progressValue;
    public Image progressBar;
    public Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }
    void Update() 
    {
        transform.LookAt(cam.transform.position);
    }

    public void UpdateProgress(float newProgress)
    {
        progressBar.fillAmount = newProgress;
        progressValue = newProgress;
    }
}
