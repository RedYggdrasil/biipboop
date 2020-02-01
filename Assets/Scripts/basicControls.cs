using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicControls : MonoBehaviour
{
    private float moveSpeed = 10f;
    
    [SerializeField]
    private Camera cam;

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        float dt = Time.deltaTime;

        transform.Translate(x*dt*moveSpeed, 0, y*dt*moveSpeed, Space.World);
        updateOrientation();
    }

    void updateOrientation() 
    {
        Vector2 mousePos = Input.mousePosition;
        Ray camRay = cam.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, 0));
        Plane flatPlane = new Plane(Vector3.up, transform.position);
        float rayLength;

        if (flatPlane.Raycast(camRay, out rayLength)) 
        {
            Vector3 lookPoint = camRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(lookPoint.x, transform.position.y, lookPoint.z));
        }
    }
    
}
