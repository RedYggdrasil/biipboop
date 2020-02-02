using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFD : MonoBehaviour
{
    Animator anim;
    bool open;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        open = false;
    }
    void OnMouseOver()
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
