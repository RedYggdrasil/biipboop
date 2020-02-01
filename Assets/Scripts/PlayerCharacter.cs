using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                GoToPosition(hit.point);
            }
        }
        base.Update();
    }

    public override void OnActivityFinished(Activity activity)
    {

    }
}
