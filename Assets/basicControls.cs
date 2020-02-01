using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicControls : MonoBehaviour
{
    private float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        float dt = Time.deltaTime;

        transform.Translate(x*dt*moveSpeed, 0, y*dt*moveSpeed);
    }
}
