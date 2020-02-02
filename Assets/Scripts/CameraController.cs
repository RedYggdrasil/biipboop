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
    [Range(0.1f, 100f)]
    public float zoomSpeed;
    [Range(1f, 30f)]
    public float zoomRange = 5;

    private Vector2 camCenter;

    private Camera cam;

    private Vector2 downLeftCorner;
    private Vector2 upRightCorner;
    private Vector3 offset;
    private float actualZoom = 0.01f;

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
        HandleZoom();
    }

    void HandleZoom()
    {
        Vector3 pos = transform.position;
        float deltazoom = Input.GetAxis("Mouse ScrollWheel");
        if (deltazoom != 0 & Mathf.Abs(actualZoom+deltazoom)*zoomSpeed <= zoomRange)
        {
            if (deltazoom+actualZoom == 0) { actualZoom += 0.001f; }
            float rangeDiff = Mathf.Clamp((actualZoom + deltazoom) * zoomSpeed, - zoomRange, zoomRange) / ((actualZoom + deltazoom) * zoomSpeed);
            if (deltazoom < 0) { rangeDiff *= -1; }
            pos += transform.forward * Time.deltaTime * zoomSpeed * rangeDiff;
            offset -= transform.forward * Time.deltaTime * zoomSpeed * rangeDiff;
            transform.position = pos;
            actualZoom += deltazoom;
            if (actualZoom == 0) { actualZoom = 0.001f; }
            actualZoom = Mathf.Clamp(actualZoom, -zoomRange/zoomSpeed, zoomRange / zoomSpeed);
        }
    }
}
