using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoucouLaPorte : MonoBehaviour
//==========================================================================
//Proximity sensor : when the mouse hovers over the GameObject, it turns to this color (red)
{
	private Color m_MouseOverColor = Color.red;
	//This stores the GameObject’s original color
	private Color m_OriginalColor;
	//Get the GameObject’s mesh renderer to access the GameObject’s material and color
	private MeshRenderer m_Renderer;

    public GameObject charniere;

    void Start()
	{
		//Fetch the mesh renderer component from the GameObject
		m_Renderer = GetComponent<MeshRenderer>();
		//Fetch the original color of the GameObject
		m_OriginalColor = m_Renderer.material.color;
	}

	void OnMouseOver()
	{
		// Change the color of the GameObject to red when the mouse is over GameObject
		m_Renderer.material.color = m_MouseOverColor;
		if (Input.GetMouseButtonDown (0)) { // When the left button is down 
			//Debug.Log ("left Mouse button is down"); // just a message in console
            charniere.transform.Rotate(0, 90, 0);

        }
		if (Input.GetMouseButtonUp (0)) { // When the left button is up 
			//Debug.Log ("left Mouse button is up"); // just a message in console
		}
    }

	void OnMouseExit()
	{
		// Reset the color of the GameObject back to normal
		m_Renderer.material.color = m_OriginalColor;
    }
}