using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : Character
{
    public LayerMask displacementClickLayer;
    Camera playerCam;

    protected override void Awake()
    {
        base.Awake();
        playerCam = Camera.main;
    }
    protected override void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, displacementClickLayer))
            {
                Debug.Log(hit.transform.gameObject.name);
                Activity touched = hit.transform.GetComponent<Activity>();
                if (touched != null && touched.playerInteractibleActivity)
                {
                    SetCurrentActivity(touched);
                }
                else
                {
                    GoToPosition(hit.point);
                }
            }
        }
        base.Update();
    }

    public void AddItem()
    {
        SceneManager.LoadScene("DevSceneTim2");
    }
}
