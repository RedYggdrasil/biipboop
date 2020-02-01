using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public BoxCollider moveArea;
    public Transform targetAgent;
    [Range(0,1)]
    public float midRectWidth;
    [Range(0,1)]
    public float midRectHeight;
    public float speed;

    private Vector2 camCenter;

    private Camera cam;

    void Start() 
    {
        cam = Camera.main;
        camCenter = new Vector2(cam.pixelWidth, cam.pixelHeight);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 agentPos = cam.WorldToScreenPoint(targetAgent.position);
        //if (agentPos.x)
    }
}
