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

    private Vector2 downLeftCorner;
    private Vector2 upRightCorner;
    private Vector3 offset;

    void Start() 
    {
        cam = Camera.main;
        camCenter = new Vector2(cam.pixelWidth * 0.5f, cam.pixelHeight * 0.5f);

        downLeftCorner = new Vector2(camCenter.x*(1-midRectWidth), camCenter.y*(1-midRectHeight));
        upRightCorner = new Vector2(camCenter.x*(1+midRectWidth), camCenter.y*(1+midRectHeight));
        print(downLeftCorner);
        print(upRightCorner);
        offset = targetAgent.position - transform.position;
        offset.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 agentPos = cam.WorldToScreenPoint(targetAgent.position);
        agentPos = new Vector2(agentPos.x, agentPos.y);
        Vector3 dist = targetAgent.position - transform.position - offset;
        dist.y = 0;
        dist = dist.normalized;
        if (agentPos.x < downLeftCorner.x || agentPos.x > upRightCorner.x)
        {
            transform.Translate(0f, 0f, dist.z*Time.deltaTime*speed,  Space.World);
        }
        if (agentPos.y < downLeftCorner.y || agentPos.y > upRightCorner.y) 
        {
            transform.Translate(dist.x*Time.deltaTime*speed, 0f, 0f,  Space.World);
        }
    }
}
