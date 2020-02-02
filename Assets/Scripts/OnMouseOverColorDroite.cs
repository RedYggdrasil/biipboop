using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverColorDroite : MonoBehaviour
{
    private Color m_MouseOverColor = Color.red;
    private Color m_OriginalColor;
    private MeshRenderer m_Renderer;
    public GameObject LaPorte;

    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_Renderer.material.color;
    }

    void OnMouseOver()
    {
        m_Renderer.material.color = m_MouseOverColor;
        if (Input.GetMouseButtonDown(0))
        {
            if (LaPorte.transform.rotation.eulerAngles.y == 270)
            {
                LaPorte.transform.Rotate(0, 90, 0);
            }
            else
            {
                LaPorte.transform.Rotate(0, -90, 0);
            }
        }
    }

    void OnMouseExit()
    {
        m_Renderer.material.color = m_OriginalColor;
    }
}