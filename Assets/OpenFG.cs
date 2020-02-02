using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFG : MonoBehaviour
{
    Animator anim;
    bool open;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        open = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (open == false)
            {
                anim.SetTrigger("Open");
                open = true;
            }
            else if (open == true)
            {
                anim.SetTrigger("Close");
                open = false;
            }

        }
    }
}
